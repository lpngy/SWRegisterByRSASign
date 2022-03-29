using HardwareInfo;
using RegisterCheck;
using RSA;
using SecCommonTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegisterForBat
{
    public partial class FormSNGen : Form
    {
        List<AppInfos> appInfoList = new List<AppInfos>();
        RegisteInfo ToProcessSoftInfos = new RegisteInfo();
        public FormSNGen()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            try
            {
                AppInfos TmpItem;
                foreach (appnames app in Enum.GetValues(typeof(appnames)))
                {
                    TmpItem = new AppInfos();
                    TmpItem.Appdisplayname = app.ToString();
                    TmpItem.AppID = app.ToString();
                    appInfoList.Add(TmpItem);
                }

                this.comboBoxapp.DataSource = appInfoList;
                this.comboBoxapp.DisplayMember = "Appdisplayname";
                this.comboBoxapp.ValueMember = "AppID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonGetID_Click(object sender, EventArgs e)
        {
            try
            {
                RegisterChecker Tmp = new RegisterChecker();
                string Tmpid,tmpsrrorinfo;
                Tmpid = Tmp.GetMachineID(out tmpsrrorinfo);
                this.textBoxID.Text = Tmpid;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSN_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.textBoxID.Text == null || this.textBoxID.Text.Trim() == "")
                {
                    MessageBox.Show("请先输入机器号！");
                    return;
                }
                if (this.textBoxMail.Text == null || this.textBoxMail.Text.Trim() == "")
                {
                    MessageBox.Show("请先输入邮箱地址！");
                    return;
                }

                this.ToProcessSoftInfos.RegistAPPName = (appnames)Enum.Parse(typeof(appnames), this.comboBoxapp.SelectedValue.ToString());
                this.ToProcessSoftInfos.UserEmailInfo = this.textBoxMail.Text.Trim();

                string TmpMcode = this.textBoxMail.Text.Trim()+this.textBoxID.Text.Trim() + this.comboBoxapp.SelectedValue.ToString();//机器码
                RSACryption TmpProcessor = new RSACryption();
                string MD5Mcode = "";
                TmpProcessor.GetHash(TmpMcode, ref MD5Mcode);

                string TmpPriaviatekeys = this.Readkeys(0);
                string TmpSN = "";
                TmpProcessor.SignatureFormatter(TmpPriaviatekeys, MD5Mcode, ref TmpSN);
                DetailInfoItem t1 = new DetailInfoItem();
                t1.UserMachineCode = this.textBoxID.Text.Trim();
                t1.UserDetailContent = TmpSN;
                this.ToProcessSoftInfos.UserDetailContent.Add(t1);
                this.richTextBoxSN.Text = TmpSN;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 读取密钥
        /// </summary>
        /// <param name="inkeytype">密钥类型，0表示私钥，1表示公钥</param>
        /// <returns></returns>
        private string Readkeys(int inkeytype)
        {
            try
            {
                string retKeys = "";
                RSACryption TmpProcessor = new RSACryption();

                if (inkeytype == 0)
                {
                    retKeys = TmpProcessor.ReadPrivateKey("infos\\privatekey");
                }
                else if (inkeytype == 1)
                {
                    retKeys = TmpProcessor.ReadPublicKey("infos\\publickey");
                }

                return retKeys;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSaveSN_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.richTextBoxSN.Text == null || this.richTextBoxSN.Text.Trim() == "")
                {
                    MessageBox.Show("请先生成序列号再进行保存！");
                    return;
                }
                SaveFileDialog TmpDialog = new SaveFileDialog();
                if (TmpDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }

                //强制修正key文件的名称
                string keyFilename = TmpDialog.FileName + ".key";
                //RSACryption TmpProcessor = new RSACryption();
                //TmpProcessor.CreateKeyXML(keyFilename, this.richTextBoxSN.Text);

                this.ToProcessSoftInfos.SaveContentToXML(keyFilename);
                MessageBox.Show("注册文件保存成功,文件名称为" + keyFilename);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonkeygen_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("此功能将生成新的密钥文件，一般情况下不需要使用，请慎重！！确认继续吗？", "提示", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }

                //选择密钥文件存放位置
                FormkeyGen Tmpform = new FormkeyGen();
                if (Tmpform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (Tmpform.PravitekeyPath == null || Tmpform.PravitekeyPath.Trim() == "")
                    {
                        MessageBox.Show("输入的私钥文件保存位置有误，请重新输入！");
                        return;
                    }
                    if (Tmpform.PublickeyPath == null || Tmpform.PublickeyPath.Trim() == "")
                    {
                        MessageBox.Show("输入的公钥文件保存位置有误，请重新输入！");
                        return;
                    }
                    //生成密钥文件
                    RSAProcessor TmpProcess = new RSAProcessor();
                    TmpProcess.RSAKey(Tmpform.PravitekeyPath,Tmpform.PublickeyPath);
                    MessageBox.Show("恭喜！新的密钥文件生成成功！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
