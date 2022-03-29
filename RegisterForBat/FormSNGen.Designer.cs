namespace RegisterForBat
{
    partial class FormSNGen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBoxSN = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxapp = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSN = new System.Windows.Forms.Button();
            this.buttonGetID = new System.Windows.Forms.Button();
            this.buttonSaveSN = new System.Windows.Forms.Button();
            this.buttonkeygen = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxMail);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.richTextBoxSN);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBoxapp);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxID);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(712, 166);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // textBoxMail
            // 
            this.textBoxMail.Location = new System.Drawing.Point(65, 48);
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(181, 21);
            this.textBoxMail.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "邮 箱：";
            // 
            // richTextBoxSN
            // 
            this.richTextBoxSN.Location = new System.Drawing.Point(65, 75);
            this.richTextBoxSN.Name = "richTextBoxSN";
            this.richTextBoxSN.ReadOnly = true;
            this.richTextBoxSN.Size = new System.Drawing.Size(636, 77);
            this.richTextBoxSN.TabIndex = 10;
            this.richTextBoxSN.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "注册码：";
            // 
            // comboBoxapp
            // 
            this.comboBoxapp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxapp.FormattingEnabled = true;
            this.comboBoxapp.Location = new System.Drawing.Point(356, 48);
            this.comboBoxapp.Name = "comboBoxapp";
            this.comboBoxapp.Size = new System.Drawing.Size(338, 20);
            this.comboBoxapp.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "需要注册的软件：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "机器码：";
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(65, 19);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(629, 21);
            this.textBoxID.TabIndex = 4;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(626, 194);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "退出";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSN
            // 
            this.buttonSN.Location = new System.Drawing.Point(423, 194);
            this.buttonSN.Name = "buttonSN";
            this.buttonSN.Size = new System.Drawing.Size(75, 23);
            this.buttonSN.TabIndex = 6;
            this.buttonSN.Text = "生成序列号";
            this.buttonSN.UseVisualStyleBackColor = true;
            this.buttonSN.Click += new System.EventHandler(this.buttonSN_Click);
            // 
            // buttonGetID
            // 
            this.buttonGetID.Location = new System.Drawing.Point(324, 194);
            this.buttonGetID.Name = "buttonGetID";
            this.buttonGetID.Size = new System.Drawing.Size(75, 23);
            this.buttonGetID.TabIndex = 5;
            this.buttonGetID.Text = "获取机器码";
            this.buttonGetID.UseVisualStyleBackColor = true;
            this.buttonGetID.Visible = false;
            this.buttonGetID.Click += new System.EventHandler(this.buttonGetID_Click);
            // 
            // buttonSaveSN
            // 
            this.buttonSaveSN.Location = new System.Drawing.Point(520, 194);
            this.buttonSaveSN.Name = "buttonSaveSN";
            this.buttonSaveSN.Size = new System.Drawing.Size(86, 23);
            this.buttonSaveSN.TabIndex = 8;
            this.buttonSaveSN.Text = "保存注册文件";
            this.buttonSaveSN.UseVisualStyleBackColor = true;
            this.buttonSaveSN.Click += new System.EventHandler(this.buttonSaveSN_Click);
            // 
            // buttonkeygen
            // 
            this.buttonkeygen.Location = new System.Drawing.Point(12, 194);
            this.buttonkeygen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonkeygen.Name = "buttonkeygen";
            this.buttonkeygen.Size = new System.Drawing.Size(88, 23);
            this.buttonkeygen.TabIndex = 13;
            this.buttonkeygen.Text = "生成密钥文件";
            this.buttonkeygen.UseVisualStyleBackColor = true;
            this.buttonkeygen.Click += new System.EventHandler(this.buttonkeygen_Click);
            // 
            // FormSNGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(738, 239);
            this.Controls.Add(this.buttonkeygen);
            this.Controls.Add(this.buttonSaveSN);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSN);
            this.Controls.Add(this.buttonGetID);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "FormSNGen";
            this.Text = "软件注册机";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTextBoxSN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxapp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSN;
        private System.Windows.Forms.Button buttonGetID;
        private System.Windows.Forms.Button buttonSaveSN;
        private System.Windows.Forms.TextBox textBoxMail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonkeygen;
    }
}