using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Management;
using Microsoft.Win32;
using System.IO;

namespace RSA
{
    public class RSAProcessor
    {
        /// <summary>
        /// 生成公私钥
        /// </summary>
        /// <param name="PrivateKeyPath"></param>
        /// <param name="PublicKeyPath"></param>
        public void RSAKey(string PrivateKeyPath, string PublicKeyPath)
        {
            try
            {
                RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
                this.CreatePrivateKeyXML(PrivateKeyPath, provider.ToXmlString(true));
                this.CreatePublicKeyXML(PublicKeyPath, provider.ToXmlString(false));
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// 对原始数据进行MD5加密
        /// </summary>
        /// <param name="m_strSource">待加密数据</param>
        /// <returns>返回机密后的数据</returns>
        public string GetHash(string m_strSource)
        {

            HashAlgorithm algorithm = HashAlgorithm.Create("MD5");

            byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(m_strSource);

            byte[] inArray = algorithm.ComputeHash(bytes);

            return Convert.ToBase64String(inArray);

        }

        /// <summary>
        /// RSA加密
        /// </summary>
        /// <param name="xmlPublicKey">公钥</param>
        /// <param name="m_strEncryptString">MD5加密后的数据</param>
        /// <returns>RSA公钥加密后的数据</returns>
        public string RSAEncrypt(string xmlPublicKey, string m_strEncryptString)
        {
            string str2;
            try
            {
                RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
                provider.FromXmlString(xmlPublicKey);
                byte[] bytes = new UnicodeEncoding().GetBytes(m_strEncryptString);
                str2 = Convert.ToBase64String(provider.Encrypt(bytes, false));
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return str2;
        }

        /// <summary>
        /// RSA解密
        /// </summary>
        /// <param name="xmlPrivateKey">私钥</param>
        /// <param name="m_strDecryptString">待解密的数据</param>
        /// <returns>解密后的结果</returns>
        public string RSADecrypt(string xmlPrivateKey, string m_strDecryptString)
        {
            string str2;

            try
            {

                RSACryptoServiceProvider provider = new RSACryptoServiceProvider();

                provider.FromXmlString(xmlPrivateKey);

                byte[] rgb = Convert.FromBase64String(m_strDecryptString);

                byte[] buffer2 = provider.Decrypt(rgb, false);

                str2 = new UnicodeEncoding().GetString(buffer2);

            }

            catch (Exception exception)
            {

                throw exception;

            }

            return str2;

        }

        /// <summary>

        /// 对MD5加密后的密文进行签名

        /// </summary>

        /// <param name="p_strKeyPrivate">私钥</param>

        /// <param name="m_strHashbyteSignature">MD5加密后的密文</param>

        /// <returns></returns>

        public string SignatureFormatter(string p_strKeyPrivate, string m_strHashbyteSignature)
        {

            byte[] rgbHash = Convert.FromBase64String(m_strHashbyteSignature);

            RSACryptoServiceProvider key = new RSACryptoServiceProvider();

            key.FromXmlString(p_strKeyPrivate);

            RSAPKCS1SignatureFormatter formatter = new RSAPKCS1SignatureFormatter(key);

            formatter.SetHashAlgorithm("MD5");

            byte[] inArray = formatter.CreateSignature(rgbHash);

            return Convert.ToBase64String(inArray);

        }

        /// <summary>

        /// 签名验证

        /// </summary>

        /// <param name="p_strKeyPublic">公钥</param>

        /// <param name="p_strHashbyteDeformatter">待验证的用户名</param>

        /// <param name="p_strDeformatterData">注册码</param>

        /// <returns></returns>

        public bool SignatureDeformatter(string p_strKeyPublic, string p_strHashbyteDeformatter, string p_strDeformatterData)
        {

            try
            {

                byte[] rgbHash = Convert.FromBase64String(p_strHashbyteDeformatter);

                RSACryptoServiceProvider key = new RSACryptoServiceProvider();

                key.FromXmlString(p_strKeyPublic);

                RSAPKCS1SignatureDeformatter deformatter = new RSAPKCS1SignatureDeformatter(key);

                deformatter.SetHashAlgorithm("MD5");

                byte[] rgbSignature = Convert.FromBase64String(p_strDeformatterData);

                if (deformatter.VerifySignature(rgbHash, rgbSignature))
                {

                    return true;

                }

                return false;

            }

            catch
            {

                return false;

            }

        }

        /// <summary>

        /// 获取硬盘ID

        /// </summary>

        /// <returns>硬盘ID</returns>

        public string GetHardID()
        {

            string HDInfo = "";

            ManagementClass cimobject1 = new ManagementClass("Win32_DiskDrive");

            ManagementObjectCollection moc1 = cimobject1.GetInstances();

            foreach (ManagementObject mo in moc1)
            {

                HDInfo = (string)mo.Properties["Model"].Value;

            }

            return HDInfo;

        }

        /// <summary>

        /// 读注册表中指定键的值

        /// </summary>

        /// <param name="key">键名</param>

        /// <returns>返回键值</returns>

        private string ReadReg(string key)
        {

            string temp = "";

            try
            {

                RegistryKey myKey = Registry.LocalMachine;

                RegistryKey subKey = myKey.OpenSubKey(@"SOFTWARE/JX/Register");



                temp = subKey.GetValue(key).ToString();

                subKey.Close();

                myKey.Close();

                return temp;

            }

            catch (Exception)
            {

                throw;//可能没有此注册项;

            }



        }

        /// <summary>

        /// 创建注册表中指定的键和值

        /// </summary>

        /// <param name="key">键名</param>

        /// <param name="value">键值</param>

        private void WriteReg(string key, string value)
        {

            try
            {

                RegistryKey rootKey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE/JX/Register");

                rootKey.SetValue(key, value);

                rootKey.Close();

            }

            catch (Exception)
            {

                throw;

            }

        }

        /// <summary>
        /// 创建公钥文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="publickey"></param>
        public void CreatePublicKeyXML(string path, string publickey)
        {
            try
            {
                
                FileStream publickeyxml = new FileStream(path, FileMode.Create);
                StreamWriter sw = new StreamWriter(publickeyxml);
                sw.WriteLine(publickey);
                sw.Close();
                publickeyxml.Close();
                
                //BinarySerialize<string> serialize = new BinarySerialize<string>();
                //serialize.Serialize(publickey, path);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 创建私钥文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="privatekey"></param>
        public void CreatePrivateKeyXML(string path, string privatekey)
        {
            try
            {
                
                FileStream privatekeyxml = new FileStream(path, FileMode.Create);
                StreamWriter sw = new StreamWriter(privatekeyxml);
                sw.WriteLine(privatekey);
                sw.Close();
                privatekeyxml.Close();
                
                //BinarySerialize<string> serialize = new BinarySerialize<string>();
                //serialize.Serialize(privatekey, path);
            }
            catch
            {
                throw;
            }

        }

        /// <summary>
        /// 读取公钥
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string ReadPublicKey(string path)
        {
            try
            {
                
                StreamReader reader = new StreamReader(path);
                string publickey = reader.ReadToEnd();
                reader.Close();
                return publickey;
                
                //BinarySerialize<string> serialize = new BinarySerialize<string>();
                //string publickey = serialize.DeSerialize(path);
                //return publickey;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 读取私钥
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string ReadPrivateKey(string path)
        {
            try
            {
                
                StreamReader reader = new StreamReader(path);
                string privatekey = reader.ReadToEnd();
                reader.Close();
                return privatekey;
                
                //BinarySerialize<string> serialize = new BinarySerialize<string>();
                //string privitekey = serialize.DeSerialize(path);
                //return privitekey;

            }
            catch
            {
                throw;
            }
        }

        /// <summary>

        /// 初始化注册表，程序运行时调用，在调用之前更新公钥xml

        /// </summary>

        /// <param name="path">公钥路径</param>

        public void InitialReg(string path)
        {

            Registry.LocalMachine.CreateSubKey(@"SOFTWARE/JX/Register");

            Random ra = new Random();

            string publickey = this.ReadPublicKey(path);

            if (Registry.LocalMachine.OpenSubKey(@"SOFTWARE/JX/Register").ValueCount <= 0)
            {

                this.WriteReg("RegisterRandom", ra.Next(1, 100000).ToString());

                this.WriteReg("RegisterPublicKey", publickey);

            }

            else
            {

                this.WriteReg("RegisterPublicKey", publickey);

            }

        } 

    }


}
