using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegisterForBat
{
    public partial class FormkeyGen : Form
    {
        public FormkeyGen()
        {
            InitializeComponent();
        }

        string pravitekeyPath;

        public string PravitekeyPath
        {
            get { return pravitekeyPath; }
            //set { pravitekeyPath = value; }
        }
        string publickeyPath;

        public string PublickeyPath
        {
            get { return publickeyPath; }
            //set { publickeyPath = value; }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (this.textBoxprivatekey.Text == null || this.textBoxprivatekey.Text.Trim() == "")
            {
                MessageBox.Show("请输入正确的私钥文件保存位置！");
                return;
            }
            if (this.textBoxpublickey.Text == null || this.textBoxpublickey.Text.Trim() == "")
            {
                MessageBox.Show("请输入正确的公钥文件保存位置！");
                return;
            }

            this.pravitekeyPath = this.textBoxprivatekey.Text.Trim();
            this.publickeyPath = this.textBoxpublickey.Text.Trim();

        }

        private void button1pri_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialogpri.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.textBoxprivatekey.Text = this.saveFileDialogpri.FileName;
            }
        }

        private void buttonpub_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialogpub.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.textBoxpublickey.Text = this.saveFileDialogpub.FileName;
            }
        }
    }
}
