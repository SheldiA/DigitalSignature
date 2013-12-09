using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace DigitalSignature
{
    public partial class FormMain : Form
    {
        private readonly int maxPrimeNumber = 256;
        public FormMain()
        {
            InitializeComponent();
        }

        private void WriteTwoByte(FileStream fs, int twoByte,int r)
        {
            string bytes = Convert.ToString(twoByte, 2);
            if(bytes.Length > 16)
                twoByte = 0;
            while (bytes.Length < 16)
                bytes = "0" + bytes;
            string firstByte = bytes.Substring(0, 8);
            string secondByte = bytes.Substring(8);
            fs.WriteByte(Convert.ToByte(firstByte, 2));
            fs.WriteByte(Convert.ToByte(secondByte, 2));
        }

        private int GetIntFromTwoByte(byte firstByte, byte secondByte)
        {
            int result = 0;

            string bytes = Convert.ToString(firstByte, 2);
            while (bytes.Length < 8)
                bytes = "0" + bytes;
            string byte2 = Convert.ToString(secondByte, 2);
            while (byte2.Length < 8)
                byte2 = "0" + byte2;
            bytes += byte2;
            result = Convert.ToInt16(bytes, 2);

            return result;
        }

        private int GetSumElements(byte[] arr, byte begin, byte offset)
        {
            int result = 0;

            for (int i = begin; i < arr.Length; i += offset)
                result += arr[i];

            return result % maxPrimeNumber;
        }

        private byte[] GetHashSHA1(string fileName)
        {
            SHA1 sha1 = new SHA1();
            FileStream fs = new FileStream(fileName, FileMode.Open);
            string hashResult = "";

            if (!(fs.Length > (Math.Pow(2,64) / 8)))
            {
                long numberBlock = fs.Length / 64;
                if (fs.Length % 64 != 0)
                    ++numberBlock;
                for (int block = 0; block < numberBlock; ++block)
                {
                    long length = (block == numberBlock - 1) ? (fs.Length - (numberBlock - 1) * 64) : 64;
                    byte[] a = new byte[length];
                    for (int i = 0; i < a.Length; ++i)
                        a[i] = (byte)fs.ReadByte();
                    string str1 = "";
                    for (int i = 0; i < a.Length; ++i)
                        str1 += Convert.ToString(a[i], 2);
                    if (str1.Length < 512)
                        str1 += "1";
                    for (int i = str1.Length; i < 448; ++i)
                        str1 += "0";
                    string str = Convert.ToString(fs.Length, 2);
                    while (str.Length < 64)
                        str = "0" + str;
                    str1 += str;
                    UInt32[] arr = new UInt32[16];
                    for (int i = 0; i < 16; ++i)
                    {
                        string temp = str1.Substring(i * 16, 16);
                        arr[i] = Convert.ToUInt32(temp, 2);
                    }
                    sha1.ProcessBlock(arr);
                }
                hashResult = sha1.GetResultHash();
            }
            else
                MessageBox.Show("Size of file shoul be less than 2^64");
            fs.Close();
            return Encoding.Default.GetBytes(hashResult);
        }

        private void bt_do_Click(object sender, EventArgs e)
        {
            FileStream sw = new FileStream(tb_saveSignature.Text, FileMode.Create);
            byte[] hashArray = GetHashSHA1(tb_failePath.Text);
            byte[] hashPassword = GetBytePassword(tb_key.Text);
            RSA rsa = new RSA(GetSumElements(hashPassword, 0, 2), GetSumElements(hashPassword, 1, 2),false,maxPrimeNumber);
            for (int i = 0; i < hashArray.Length; ++i)
            {
                int cipherByte = rsa.Encrypt(hashArray[i]);
                WriteTwoByte(sw, cipherByte,rsa.p * rsa.q);
            }
            sw.Close();
        }

        private byte[] GetBytePassword(string initial_string)
        {
            MD5 md5hash = MD5.Create();
            byte[] data = md5hash.ComputeHash(Encoding.UTF8.GetBytes(initial_string));
            return data;
        }

        private void bt_open_Click(object sender, EventArgs e)
        {
            if ((openFileDialog1.ShowDialog() == DialogResult.OK) && (openFileDialog1.FileName.Length > 0))
                tb_failePath.Text = openFileDialog1.FileName;
        }

        private void bt_saveSign_Click(object sender, EventArgs e)
        {
            if ((saveFileDialog1.ShowDialog() == DialogResult.OK) && (saveFileDialog1.FileName.Length > 0))
                tb_saveSignature.Text = saveFileDialog1.FileName;
        }

        private void bt_openSign_Click(object sender, EventArgs e)
        {
            if ((openFileDialog1.ShowDialog() == DialogResult.OK) && (openFileDialog1.FileName.Length > 0))
                tb_openSignature.Text = openFileDialog1.FileName;
        }

        private void bt_authentication_Click(object sender, EventArgs e)
        {
            byte[] hashFromMessage = GetHashSHA1(tb_failePath.Text);
            
            byte[] hashPassword = GetBytePassword(tb_key.Text);
            RSA rsa = new RSA(GetSumElements(hashPassword, 0, 2), GetSumElements(hashPassword, 1, 2), false,maxPrimeNumber);
            FileStream sr = new FileStream(tb_openSignature.Text, FileMode.Open);
            byte[] hashFromDecrypt = new byte[sr.Length / 2];
            for (int i = 0; i < sr.Length / 2; ++i)
            {
                int cipherByte = GetIntFromTwoByte((byte)sr.ReadByte(), (byte)sr.ReadByte());
                hashFromDecrypt[i] = (byte)rsa.Decrypt(cipherByte);
            }

            if (hashFromDecrypt.Length == hashFromMessage.Length)
            {
                bool isAuthentic = true;
                for (int i = 0; i < hashFromMessage.Length; ++i)
                    if (hashFromMessage[i] != hashFromDecrypt[i])
                    {
                        isAuthentic = false;
                        break;
                    }
                if(!isAuthentic)
                    MessageBox.Show("Digital signature isn't authentic!");
                else
                    MessageBox.Show("Digital signature is authentic!");
            }
            else
                MessageBox.Show("Digital signature isn't authentic!");

            sr.Close();
        }
    }
}
