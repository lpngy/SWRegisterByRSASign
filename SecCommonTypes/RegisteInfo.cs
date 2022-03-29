//using NewLogWriter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SecCommonTypes
{
    [Serializable]
    public class RegisteInfo
    {
        string userEmailInfo;

        public string UserEmailInfo
        {
            get { return userEmailInfo; }
            set { userEmailInfo = value; }
        }

        appnames registAPPName;

        public appnames RegistAPPName
        {
            get { return registAPPName; }
            set { registAPPName = value; }
        }

        List<DetailInfoItem> userDetailContent;

        public List<DetailInfoItem> UserDetailContent
        {
            get { return userDetailContent; }
            set { userDetailContent = value; }
        }



        public RegisteInfo()
        {
            this.userDetailContent = new List<DetailInfoItem>();
            this.userEmailInfo = "";
            this.registAPPName = appnames.none;

        }


        public int SaveContentToXML(string inFileName)
        {
            try
            {
                //序列化将信息写入xml文件
                XmlSerializer mySerializer = new XmlSerializer(typeof(RegisteInfo));
                // To write to a file, create a StreamWriter object.
                StreamWriter myWriter = new StreamWriter(inFileName);
                mySerializer.Serialize(myWriter, this);
                myWriter.Close();
                return 0;
            }
            catch (Exception ex)
            {
                //GlobalStatusReport.ReportError(ex);
                return -1;
            }
        }


        public int LoadContentFromXML(string inFileName)
        {
            try
            {
                if (File.Exists(inFileName))
                {
                    RegisteInfo TmpRegisteInfo = new RegisteInfo();
                    FileStream fs = new FileStream(inFileName, FileMode.Open);
                    XmlSerializer formatter = new XmlSerializer(typeof(RegisteInfo));
                    TmpRegisteInfo = (RegisteInfo)formatter.Deserialize(fs);
                    fs.Close();

                    if (TmpRegisteInfo != null)
                    {
                        UserEmailInfo = TmpRegisteInfo.UserEmailInfo;
                        userDetailContent = TmpRegisteInfo.userDetailContent;
                        registAPPName = TmpRegisteInfo.RegistAPPName;
                    }
                    else
                    {
                        //MessageBox.Show("读取的内容为空！");
                    }
                }
                else
                {
                   // MessageBox.Show("未找到指定的系统设置文件，读取文件内容失败。。。。。。");
                    //GlobalStatusReport.Report("未找到指定的系统设置文件，读取文件内容失败。。。。。。");
                }
                return 0;
            }
            catch (Exception ex)
            {
                //GlobalStatusReport.ReportError(ex);
                return -1;
            }
        }



    }
}
