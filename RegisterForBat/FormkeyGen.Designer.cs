namespace RegisterForBat
{
    partial class FormkeyGen
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxprivatekey = new System.Windows.Forms.TextBox();
            this.textBoxpublickey = new System.Windows.Forms.TextBox();
            this.button1pri = new System.Windows.Forms.Button();
            this.buttonpub = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.saveFileDialogpri = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialogpub = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonpub);
            this.groupBox1.Controls.Add(this.button1pri);
            this.groupBox1.Controls.Add(this.textBoxpublickey);
            this.groupBox1.Controls.Add(this.textBoxprivatekey);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1129, 157);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "私钥文件存放路径：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "公钥文件存放路径：";
            // 
            // textBoxprivatekey
            // 
            this.textBoxprivatekey.Location = new System.Drawing.Point(257, 30);
            this.textBoxprivatekey.Name = "textBoxprivatekey";
            this.textBoxprivatekey.Size = new System.Drawing.Size(775, 35);
            this.textBoxprivatekey.TabIndex = 2;
            // 
            // textBoxpublickey
            // 
            this.textBoxpublickey.Location = new System.Drawing.Point(257, 90);
            this.textBoxpublickey.Name = "textBoxpublickey";
            this.textBoxpublickey.Size = new System.Drawing.Size(775, 35);
            this.textBoxpublickey.TabIndex = 3;
            // 
            // button1pri
            // 
            this.button1pri.Location = new System.Drawing.Point(1038, 26);
            this.button1pri.Name = "button1pri";
            this.button1pri.Size = new System.Drawing.Size(59, 39);
            this.button1pri.TabIndex = 1;
            this.button1pri.Text = "...";
            this.button1pri.UseVisualStyleBackColor = true;
            this.button1pri.Click += new System.EventHandler(this.button1pri_Click);
            // 
            // buttonpub
            // 
            this.buttonpub.Location = new System.Drawing.Point(1038, 86);
            this.buttonpub.Name = "buttonpub";
            this.buttonpub.Size = new System.Drawing.Size(59, 39);
            this.buttonpub.TabIndex = 4;
            this.buttonpub.Text = "...";
            this.buttonpub.UseVisualStyleBackColor = true;
            this.buttonpub.Click += new System.EventHandler(this.buttonpub_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(269, 194);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(116, 42);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(676, 194);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(111, 42);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // FormkeyGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 284);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "FormkeyGen";
            this.Text = "生成密钥文件";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonpub;
        private System.Windows.Forms.Button button1pri;
        private System.Windows.Forms.TextBox textBoxpublickey;
        private System.Windows.Forms.TextBox textBoxprivatekey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.SaveFileDialog saveFileDialogpri;
        private System.Windows.Forms.SaveFileDialog saveFileDialogpub;
    }
}