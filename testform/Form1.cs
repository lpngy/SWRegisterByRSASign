using RegisterCheck;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using SecCommonTypes;

namespace testform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegisterChecker tmp = new RegisterChecker();
            string reeroinfo = "";
            //int TmpResult = tmp.CheckIfRegisted("lpngy@qq.com",appnames.TestApp1,out reeroinfo );
            OpenFileDialog TmpDialog = new OpenFileDialog();
            TmpDialog.Filter = "注册文件|*.key";
            if(TmpDialog.ShowDialog()!= System.Windows.Forms.DialogResult.OK)
            { return; }

            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(TmpDialog.FileName);


            int TmpResult = tmp.Verificationtest(this.textBox1.Text, xdoc.InnerXml, out reeroinfo);

            MessageBox.Show(TmpResult.ToString());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegisterChecker tmp = new RegisterChecker();
            string reeroinfo = "";
            string ID = "";
            //ID = tmp.GetMachineIDIncludeIP(out reeroinfo);
            ID = tmp.GetMachineID(out reeroinfo);            
           // MessageBox.Show(ID);
            this.textBox1.Text = ID;
        }

    }
}
