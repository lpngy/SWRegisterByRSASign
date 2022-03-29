/*
 * 修改记录
 * 修改时间：20171212 
 * 修改人：eddy 
 * 修改原因：现场反馈授权信息的mac和ip在电脑上存在多个的情况，会出现申请授权的信息和验证信息的mac和ip不一致造成授权验证失败。
 * 解决方法:获取物理网卡的mac和ip(无效网卡和虚拟网卡舍弃，如果存在多个物理网卡，则默认选一组）申请授权，在验证授权的时候轮巡物理网卡的mac和ip进行匹配。
 * 修改代码：
 *          新增函数:
 *          public List<string> GetMachineIDIncludeIPs(out string retErrorInfo)
 *          public int Verificationtest(string VerifyContent, out string retErrorInfo)
 *          public List<string> GetUserMachineCodes(string VerifyContent)
*/


using HardwareInfo;
using RSA;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using SecCommonTypes;

namespace RegisterCheck
{
    public class RegisterChecker
    {
        /// <summary>
        /// 用于检测某软件是否被注册。验证的流程是：1、检查是否具有注册文件。
        /// 2、验证注册文件中的注册码是否能正常读出 3、验证注册码是否有效
        /// 验证的时候需要机器码、公钥、注册码
        /// </summary>
        /// <regMailaddress>注册用户的邮箱地址</regMailaddress>
        /// <CheckAPPName>需要验证的软件名称：目前仅支持：</CheckAPPName>
        /// <retErrorInfo>如果发生异常，则由此参数返回异常信息，如果执行成功，则此参数返回空字符串</retErrorInfo>
        /// <returns>返回0说明验证成功，返回10说明key文件不存在，返回20说明读取注册码失败,
        /// 返回30说明公钥文件不存在，范围40说明读取公钥文件失败，返回50说明读取机器码失败,
        /// 返回60表示签名验证失败</returns>
        public int CheckIfRegisted(string regMailaddress, appnames CheckAPPName, out string retErrorInfo)
        {
            retErrorInfo = "";
            try
            {
                //读取注册码
                string keyfile = Application.StartupPath + "\\infos\\"+regMailaddress+".key";
                if (!File.Exists(keyfile))
                {
                    return 10;
                }
               
                RSACryption TmpProcessor = new RSACryption();
                string key = TmpProcessor.ReadPublicKey(keyfile);
                if (key == null || key.Trim() == "")
                {
                    return 20;
                }

                //读取公钥
                if (!File.Exists(Application.StartupPath + "\\infos\\publickey"))
                {
                    return 30;
                }
                string Publickey = TmpProcessor.ReadPublicKey(Application.StartupPath + "\\infos\\publickey");
                if (Publickey == null || Publickey.Trim() == "")
                {
                    return 40;
                }

                //获取机器码，uuID+cpu序号+mac地址
                CHardwareInfo Tmp = new CHardwareInfo();
                string TmpMcode = Tmp.GetUUID() + Tmp.GetCpuID()+Tmp.GetNetCardMacAddress();
                string TmpMcodeMD5 = "";
                if (!TmpProcessor.GetHash(regMailaddress + TmpMcode + CheckAPPName.ToString(), ref TmpMcodeMD5))
                {
                    return 50;
                }
                
                //验证
                bool tmp = TmpProcessor.SignatureDeformatter(Publickey, TmpMcodeMD5, key);
                if (tmp)
                {
                    return 0;
                }
                else
                {
                    return 60;
                }
            }
            catch (Exception ex)
            {
                retErrorInfo = ex.Message;
                return -1;
            }
            
        }

        /// <summary>
        /// 获取机器码,机器码格式为UUIDCPUIDMac
        /// </summary>
        /// <param name="retErrorInfo">如果发生异常，则由此参数返回异常信息，如果执行成功，则此参数返回空字符串</param>
        /// <returns>返回机器码</returns>
        public string GetMachineID(out string retErrorInfo)
        {
            retErrorInfo = "";
            try
            {
                //获取机器码，uuID+cpu序号+mac地址
                CHardwareInfo Tmp = new CHardwareInfo();
                string Tmpid = Tmp.GetUUID() + Tmp.GetCpuID() + Tmp.GetNetCardMacAddress();
                return Tmpid;
            }
            catch (Exception ex)
            {
                retErrorInfo = ex.Message;
                return "";
            }
        }

        /// <summary>
        /// 获取机器码,机器码格式为“UUIDCPUIDMac+IP”检查字符串中的加号可以分离出ip地址
        /// </summary>
        /// <param name="retErrorInfo"></param>
        /// <returns>如果发生异常，则由此参数返回异常信息，如果执行成功，则此参数返回空字符串</returns>
        public string GetMachineIDIncludeIP(out string retErrorInfo)
        {
            retErrorInfo = "";
            try
            {
                //获取机器码，uuID+cpu序号+mac地址+IP
                CHardwareInfo Tmp = new CHardwareInfo();

                string Tmpid = Tmp.GetUUID() + Tmp.GetCpuID() + Tmp.GetNetCardMacAddress() + "+" + PublicMethods.GetAddressIP();
                return Tmpid;

            }
            catch (Exception ex)
            {
                retErrorInfo = ex.Message;
                return "";
            }
        }

        /// <summary>
        /// 用于检测某软件是否被注册。
        /// </summary>
        /// <param name="MachineID">机器id</param>
        /// <param name="VerifyContent">字符串形式的注册码内容</param>
        /// <param name="retErrorInfo">如果发生异常，则由此参数返回异常信息，如果执行成功，则此参数返回空字符串</param>
        /// <returns>返回0说明验证成功，
        /// 返回10说明读取传入的注册信息失败，
        /// 返回20说明从传入的注册信息中分析注册信息时得到的注册信息结果为空,
        /// 返回30说明传入的注册信息中不包含任何一条注册码信息！
        /// 返回40说明传入的注册信息中不包含注册的程序系统名称信息！
        /// 返回50说明传入的注册信息中不包含注册的邮箱信息！
        /// 返回60表示公钥文件不存在
        /// 返回70说明读取公钥信息失败
        /// 返回80说明获取机器码的哈希码时失败
        /// 返回90说明验证失败
        /// 返回-1说明出现异常，异常信息可在最后一个返回参数中查看</returns>
        public int Verificationtest(string MachineID,  string VerifyContent,out string retErrorInfo)
        {
            try
            {
                //首先解析注册信息
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(VerifyContent);
                xdoc.Save("tmpreginfo");

                RegisteInfo TmpSWInfo = new RegisteInfo();
                int TmpResult = TmpSWInfo.LoadContentFromXML("tmpreginfo");
                if(TmpResult != 0)
                {
                    retErrorInfo = "读取传入的注册信息失败！";
                    return 10;
                }

                if(TmpSWInfo == null )
                {
                    retErrorInfo = "从传入的注册信息中分析注册信息时得到的注册信息结果为空！";
                    return 20;
                }

                if( TmpSWInfo.UserDetailContent == null || TmpSWInfo.UserDetailContent.Count<=0)
                {
                    retErrorInfo = "传入的注册信息中不包含任何一条注册码信息！";
                    return 30;
                }

                if (TmpSWInfo.RegistAPPName == appnames.none)
                {
                    retErrorInfo = "传入的注册信息中不包含注册的程序系统名称信息！";
                    return 40;
                }

                if(TmpSWInfo.UserEmailInfo == null || TmpSWInfo.UserEmailInfo.Trim() == "")
                {
                    retErrorInfo = "传入的注册信息中不包含注册的邮箱信息！";
                    return 50;
                }

                //从传入的机器码中获取对应的注册码
                string TmpregCode = "";
                foreach (DetailInfoItem TmpItem in TmpSWInfo.UserDetailContent)
                {
                    if(TmpItem.UserMachineCode == MachineID)
                    {
                        TmpregCode = TmpItem.UserDetailContent;
                        break;
                    }
                }

                //验证注册信息
                //读取公钥
                RSACryption TmpProcessor = new RSACryption();
                if (!File.Exists(Application.StartupPath + "\\infos\\publickey"))
                {
                    retErrorInfo = "公钥文件不存在";
                    return 60;
                }
                string Publickey = TmpProcessor.ReadPublicKey(Application.StartupPath + "\\infos\\publickey");
                if (Publickey == null || Publickey.Trim() == "")
                {
                    retErrorInfo = "读取公钥信息失败";
                    return 70;
                }

                //
                
                string TmpMcodeMD5 = "";
                if (!TmpProcessor.GetHash(TmpSWInfo.UserEmailInfo + MachineID + TmpSWInfo.RegistAPPName.ToString(), ref TmpMcodeMD5))
                {
                    retErrorInfo = "获取机器码的哈希码时失败";
                    return 80;
                }

                //验证
                bool tmp = TmpProcessor.SignatureDeformatter(Publickey, TmpMcodeMD5, TmpregCode);
                if (tmp)
                {
                    retErrorInfo = "";
                    return 0;
                }
                else
                {
                    retErrorInfo = "验证失败，无效的注册码！";
                    return 90;
                }
            }
            catch (Exception ex)
            {
                retErrorInfo = ex.Message;
                return -1;
            }
        }

        #region 20171212 add by eddy
        /// <summary>
        /// 获取机器码,机器码格式为“UUIDCPUIDMac+IP”检查字符串中的加号可以分离出ip地址
        /// </summary>
        /// <param name="retErrorInfo"></param>
        /// <returns>如果发生异常，则由此参数返回异常信息，如果执行成功，则此参数返回空字符串</returns>
        public List<string> GetMachineIDIncludeIPs(out string retErrorInfo)
        {
            retErrorInfo = "";
            List<string> list = new List<string>();
            try
            {
                //获取机器码，uuID+cpu序号+mac地址+IP
                CHardwareInfo Tmp = new CHardwareInfo();
                string Tmpid = Tmp.GetUUID() + Tmp.GetCpuID();
                List<string> macAndIPs = Tmp.GetHardwareMacAddressAndIP();
                if (macAndIPs.Count > 0)
                {
                    foreach (string macandip in macAndIPs)
                    {
                        list.Add(Tmpid + macandip);
                    }
                }
                else
                {
                    retErrorInfo = "获取机器码信息为空";
                }
            }
            catch (Exception ex)
            {
                retErrorInfo ="获取机器码信息异常:"+ ex.Message;
            }

            return list;
        }

        /// <summary>
        /// 用于检测某软件是否被注册。
        /// </summary>
        /// <param name="VerifyContent">字符串形式的注册码内容</param>
        /// <param name="retErrorInfo">如果发生异常，则由此参数返回异常信息，如果执行成功，则此参数返回空字符串</param>
        /// <returns>返回0说明验证成功，
        /// 返回10说明读取传入的注册信息失败，
        /// 返回20说明从传入的注册信息中分析注册信息时得到的注册信息结果为空,
        /// 返回30说明传入的注册信息中不包含任何一条注册码信息！
        /// 返回40说明传入的注册信息中不包含注册的程序系统名称信息！
        /// 返回50说明传入的注册信息中不包含注册的邮箱信息！
        /// 返回60表示公钥文件不存在
        /// 返回70说明读取公钥信息失败
        /// 返回80说明获取机器码的哈希码时失败
        /// 返回90说明验证失败
        /// 返回-1说明出现异常，异常信息可在最后一个返回参数中查看</returns>
        public int Verificationtest(string VerifyContent, out string retErrorInfo)
        {
            try
            {
                //首先解析注册信息
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(VerifyContent);
                xdoc.Save("tmpreginfo");

                RegisteInfo TmpSWInfo = new RegisteInfo();
                int TmpResult = TmpSWInfo.LoadContentFromXML("tmpreginfo");
                if (TmpResult != 0)
                {
                    retErrorInfo = "读取传入的注册信息失败！";
                    return 10;
                }

                if (TmpSWInfo == null)
                {
                    retErrorInfo = "从传入的注册信息中分析注册信息时得到的注册信息结果为空！";
                    return 20;
                }

                if (TmpSWInfo.UserDetailContent == null || TmpSWInfo.UserDetailContent.Count <= 0)
                {
                    retErrorInfo = "传入的注册信息中不包含任何一条注册码信息！";
                    return 30;
                }

                if (TmpSWInfo.RegistAPPName == appnames.none)
                {
                    retErrorInfo = "传入的注册信息中不包含注册的程序系统名称信息！";
                    return 40;
                }

                if (TmpSWInfo.UserEmailInfo == null || TmpSWInfo.UserEmailInfo.Trim() == "")
                {
                    retErrorInfo = "传入的注册信息中不包含注册的邮箱信息！";
                    return 50;
                }

                //从传入的机器码中获取对应的注册码
                bool issuccess = false;
                string TmpregCode = "";
                CHardwareInfo hinfo = new CHardwareInfo();
                string MachineID = hinfo.GetUUID() + hinfo.GetCpuID();
                List<string> macAndIPs = hinfo.GetHardwareMacAddressAndIP();
                if (macAndIPs.Count > 0)
                {
                    foreach (DetailInfoItem TmpItem in TmpSWInfo.UserDetailContent)
                    {
                        foreach (string macandip in macAndIPs)
                        {
                            //轮询mac和ip
                            if (TmpItem.UserMachineCode == MachineID + macandip)
                            {
                                MachineID += macandip;
                                TmpregCode = TmpItem.UserDetailContent;
                                issuccess = true;

                                break;
                            }
                        }

                        //是否已经匹配成功
                        if (issuccess)
                            break;
                    }
                }

                //验证注册信息
                //读取公钥
                RSACryption TmpProcessor = new RSACryption();
                if (!File.Exists(Application.StartupPath + "\\infos\\publickey"))
                {
                    retErrorInfo = "公钥文件不存在";
                    return 60;
                }
                string Publickey = TmpProcessor.ReadPublicKey(Application.StartupPath + "\\infos\\publickey");
                if (Publickey == null || Publickey.Trim() == "")
                {
                    retErrorInfo = "读取公钥信息失败";
                    return 70;
                }

                //

                string TmpMcodeMD5 = "";
                if (!TmpProcessor.GetHash(TmpSWInfo.UserEmailInfo + MachineID + TmpSWInfo.RegistAPPName.ToString(), ref TmpMcodeMD5))
                {
                    retErrorInfo = "获取机器码的哈希码时失败";
                    return 80;
                }

                //验证
                bool tmp = TmpProcessor.SignatureDeformatter(Publickey, TmpMcodeMD5, TmpregCode);
                if (tmp)
                {
                    retErrorInfo = "";
                    return 0;
                }
                else
                {
                    retErrorInfo = "验证失败，无效的注册码！";
                    return 90;
                }
            }
            catch (Exception ex)
            {
                retErrorInfo = ex.Message;
                return -1;
            }
        }

        /// <summary>
        /// 获取已注册用户的机器码信息
        /// </summary>
        /// <param name="VerifyContent"></param>
        /// <returns></returns>
        public List<string> GetUserMachineCodes(string VerifyContent)
        {
            List<string> machinecodes = new List<string>();

            try
            {
                //首先解析注册信息
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(VerifyContent);
                xdoc.Save("tmpreginfo");

                RegisteInfo TmpSWInfo = new RegisteInfo();
                int TmpResult = TmpSWInfo.LoadContentFromXML("tmpreginfo");
                if (TmpResult == 0 && TmpSWInfo != null && TmpSWInfo.UserDetailContent != null && TmpSWInfo.UserDetailContent.Count > 0 && TmpSWInfo.RegistAPPName != appnames.none)
                {
                    foreach (DetailInfoItem TmpItem in TmpSWInfo.UserDetailContent)
                    {
                        machinecodes.Add(TmpItem.UserMachineCode);
                    }
                }

            }
            catch{

            }

            return machinecodes;
        }
        #endregion
    }
}
