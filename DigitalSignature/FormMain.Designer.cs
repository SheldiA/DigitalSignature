namespace DigitalSignature
{
    partial class FormMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_do = new System.Windows.Forms.Button();
            this.bt_authentication = new System.Windows.Forms.Button();
            this.tb_failePath = new System.Windows.Forms.TextBox();
            this.bt_open = new System.Windows.Forms.Button();
            this.tb_key = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tb_saveSignature = new System.Windows.Forms.TextBox();
            this.tb_openSignature = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_openSign = new System.Windows.Forms.Button();
            this.bt_saveSign = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bt_do
            // 
            this.bt_do.Location = new System.Drawing.Point(23, 230);
            this.bt_do.Name = "bt_do";
            this.bt_do.Size = new System.Drawing.Size(142, 41);
            this.bt_do.TabIndex = 0;
            this.bt_do.Text = "Generate digital signature";
            this.bt_do.UseVisualStyleBackColor = true;
            this.bt_do.Click += new System.EventHandler(this.bt_do_Click);
            // 
            // bt_authentication
            // 
            this.bt_authentication.Location = new System.Drawing.Point(244, 230);
            this.bt_authentication.Name = "bt_authentication";
            this.bt_authentication.Size = new System.Drawing.Size(131, 41);
            this.bt_authentication.TabIndex = 1;
            this.bt_authentication.Text = "Authentication of digital signature";
            this.bt_authentication.UseVisualStyleBackColor = true;
            this.bt_authentication.Click += new System.EventHandler(this.bt_authentication_Click);
            // 
            // tb_failePath
            // 
            this.tb_failePath.Location = new System.Drawing.Point(23, 23);
            this.tb_failePath.Name = "tb_failePath";
            this.tb_failePath.Size = new System.Drawing.Size(190, 20);
            this.tb_failePath.TabIndex = 2;
            // 
            // bt_open
            // 
            this.bt_open.Location = new System.Drawing.Point(244, 22);
            this.bt_open.Name = "bt_open";
            this.bt_open.Size = new System.Drawing.Size(91, 20);
            this.bt_open.TabIndex = 3;
            this.bt_open.Text = "...";
            this.bt_open.UseVisualStyleBackColor = true;
            this.bt_open.Click += new System.EventHandler(this.bt_open_Click);
            // 
            // tb_key
            // 
            this.tb_key.Location = new System.Drawing.Point(23, 178);
            this.tb_key.Name = "tb_key";
            this.tb_key.Size = new System.Drawing.Size(189, 20);
            this.tb_key.TabIndex = 4;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tb_saveSignature
            // 
            this.tb_saveSignature.Location = new System.Drawing.Point(22, 78);
            this.tb_saveSignature.Name = "tb_saveSignature";
            this.tb_saveSignature.Size = new System.Drawing.Size(190, 20);
            this.tb_saveSignature.TabIndex = 5;
            // 
            // tb_openSignature
            // 
            this.tb_openSignature.Location = new System.Drawing.Point(22, 130);
            this.tb_openSignature.Name = "tb_openSignature";
            this.tb_openSignature.Size = new System.Drawing.Size(190, 20);
            this.tb_openSignature.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Choose file for saving signature : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Choose file with signature : ";
            // 
            // bt_openSign
            // 
            this.bt_openSign.Location = new System.Drawing.Point(244, 129);
            this.bt_openSign.Name = "bt_openSign";
            this.bt_openSign.Size = new System.Drawing.Size(91, 20);
            this.bt_openSign.TabIndex = 10;
            this.bt_openSign.Text = "...";
            this.bt_openSign.UseVisualStyleBackColor = true;
            this.bt_openSign.Click += new System.EventHandler(this.bt_openSign_Click);
            // 
            // bt_saveSign
            // 
            this.bt_saveSign.Location = new System.Drawing.Point(244, 78);
            this.bt_saveSign.Name = "bt_saveSign";
            this.bt_saveSign.Size = new System.Drawing.Size(91, 20);
            this.bt_saveSign.TabIndex = 11;
            this.bt_saveSign.Text = "...";
            this.bt_saveSign.UseVisualStyleBackColor = true;
            this.bt_saveSign.Click += new System.EventHandler(this.bt_saveSign_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Choose file with message :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Enter key : ";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 283);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bt_saveSign);
            this.Controls.Add(this.bt_openSign);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_openSignature);
            this.Controls.Add(this.tb_saveSignature);
            this.Controls.Add(this.tb_key);
            this.Controls.Add(this.bt_open);
            this.Controls.Add(this.tb_failePath);
            this.Controls.Add(this.bt_authentication);
            this.Controls.Add(this.bt_do);
            this.Name = "FormMain";
            this.Text = "Digital signature";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_do;
        private System.Windows.Forms.Button bt_authentication;
        private System.Windows.Forms.TextBox tb_failePath;
        private System.Windows.Forms.Button bt_open;
        private System.Windows.Forms.TextBox tb_key;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox tb_saveSignature;
        private System.Windows.Forms.TextBox tb_openSignature;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_openSign;
        private System.Windows.Forms.Button bt_saveSign;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

