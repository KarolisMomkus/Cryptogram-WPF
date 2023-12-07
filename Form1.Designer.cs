namespace Kriptograma_WPF
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxPassword = new TextBox();
            label3 = new Label();
            textBoxKey = new TextBox();
            label4 = new Label();
            label5 = new Label();
            Method_AES = new CheckBox();
            Method_3DES = new CheckBox();
            buttonStart = new Button();
            label1 = new Label();
            radioButtonEncrypt = new RadioButton();
            radioButtonDecrypt = new RadioButton();
            textBoxResults = new TextBox();
            label2 = new Label();
            textBoxWarnings = new TextBox();
            SuspendLayout();
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(101, 27);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(163, 23);
            textBoxPassword.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(48, 30);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 3;
            label3.Text = "Tekstas:";
            // 
            // textBoxKey
            // 
            textBoxKey.Location = new Point(101, 67);
            textBoxKey.Name = "textBoxKey";
            textBoxKey.Size = new Size(163, 23);
            textBoxKey.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(51, 70);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 5;
            label4.Text = "Raktas:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(55, 108);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 6;
            label5.Text = "Būdai:";
            // 
            // Method_AES
            // 
            Method_AES.AutoSize = true;
            Method_AES.Location = new Point(101, 107);
            Method_AES.Name = "Method_AES";
            Method_AES.Size = new Size(46, 19);
            Method_AES.TabIndex = 7;
            Method_AES.Text = "AES";
            Method_AES.UseVisualStyleBackColor = true;
            // 
            // Method_3DES
            // 
            Method_3DES.AutoSize = true;
            Method_3DES.Location = new Point(212, 107);
            Method_3DES.Name = "Method_3DES";
            Method_3DES.Size = new Size(52, 19);
            Method_3DES.TabIndex = 8;
            Method_3DES.Text = "3DES";
            Method_3DES.UseVisualStyleBackColor = true;
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(101, 185);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(163, 23);
            buttonStart.TabIndex = 9;
            buttonStart.Text = "Vykdyti";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 143);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 10;
            label1.Text = "Veiksmas:";
            // 
            // radioButtonEncrypt
            // 
            radioButtonEncrypt.AutoSize = true;
            radioButtonEncrypt.Location = new Point(101, 139);
            radioButtonEncrypt.Name = "radioButtonEncrypt";
            radioButtonEncrypt.Size = new Size(79, 19);
            radioButtonEncrypt.TabIndex = 11;
            radioButtonEncrypt.TabStop = true;
            radioButtonEncrypt.Text = "Užkoduoti";
            radioButtonEncrypt.UseVisualStyleBackColor = true;
            radioButtonEncrypt.CheckedChanged += radioButtonEncrypt_CheckedChanged;
            // 
            // radioButtonDecrypt
            // 
            radioButtonDecrypt.AutoSize = true;
            radioButtonDecrypt.Location = new Point(186, 139);
            radioButtonDecrypt.Name = "radioButtonDecrypt";
            radioButtonDecrypt.Size = new Size(78, 19);
            radioButtonDecrypt.TabIndex = 12;
            radioButtonDecrypt.TabStop = true;
            radioButtonDecrypt.Text = "Atkoduoti";
            radioButtonDecrypt.UseVisualStyleBackColor = true;
            radioButtonDecrypt.CheckedChanged += radioButtonDecrypt_CheckedChanged;
            // 
            // textBoxResults
            // 
            textBoxResults.Location = new Point(101, 240);
            textBoxResults.Multiline = true;
            textBoxResults.Name = "textBoxResults";
            textBoxResults.ReadOnly = true;
            textBoxResults.Size = new Size(358, 102);
            textBoxResults.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 243);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 14;
            label2.Text = "Rezultatas:";
            // 
            // textBoxWarnings
            // 
            textBoxWarnings.BorderStyle = BorderStyle.None;
            textBoxWarnings.ForeColor = SystemColors.WindowText;
            textBoxWarnings.Location = new Point(286, 27);
            textBoxWarnings.Multiline = true;
            textBoxWarnings.Name = "textBoxWarnings";
            textBoxWarnings.ReadOnly = true;
            textBoxWarnings.Size = new Size(173, 181);
            textBoxWarnings.TabIndex = 15;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(497, 360);
            Controls.Add(textBoxWarnings);
            Controls.Add(label2);
            Controls.Add(textBoxResults);
            Controls.Add(radioButtonDecrypt);
            Controls.Add(radioButtonEncrypt);
            Controls.Add(label1);
            Controls.Add(buttonStart);
            Controls.Add(Method_3DES);
            Controls.Add(Method_AES);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(textBoxKey);
            Controls.Add(label3);
            Controls.Add(textBoxPassword);
            Name = "Form1";
            Text = "Užkodavimas - Atkodavimas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBoxPassword;
        private Label label3;
        private TextBox textBoxKey;
        private Label label4;
        private Label label5;
        private CheckBox Method_AES;
        private CheckBox Method_3DES;
        private Button buttonStart;
        private Label label6;
        private Label label1;
        private RadioButton radioButtonEncrypt;
        private RadioButton radioButtonDecrypt;
        private TextBox textBoxResults;
        private Label label2;
        private TextBox textBoxWarnings;
    }
}