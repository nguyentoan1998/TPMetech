using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tín_Phát_Metech
{
    public class ecryption
    {
        string pathEncrypt = Application.StartupPath + @"\Data\Data";
        string pathDecrypt = Application.StartupPath + @"\Data\Datade.txt";
        string Encrypt(string source, string key)
        {
            using (TripleDESCryptoServiceProvider tripleDESCryptoService = new TripleDESCryptoServiceProvider())
            {
                using (MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider())
                {
                    byte[] byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(key));
                    tripleDESCryptoService.Key = byteHash;
                    tripleDESCryptoService.Mode = CipherMode.ECB;
                    byte[] data = Encoding.UTF8.GetBytes(source);
                    return Convert.ToBase64String(tripleDESCryptoService.CreateEncryptor().TransformFinalBlock(data, 0, data.Length));
                }
            }
        }
        string Decrypt(string encrypt, string key)
        {
            using (TripleDESCryptoServiceProvider tripleDESCryptoService = new TripleDESCryptoServiceProvider())
            {
                using (MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider())
                {
                    byte[] byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(key));
                    tripleDESCryptoService.Key = byteHash;
                    tripleDESCryptoService.Mode = CipherMode.ECB;
                    byte[] data = Convert.FromBase64String(encrypt);
                    return Encoding.UTF8.GetString(tripleDESCryptoService.CreateDecryptor().TransformFinalBlock(data, 0, data.Length));
                }
            }
        }
        public void EncryptData(string data)
        {
            string TextBox = Encrypt(data, "DoBanDoDuocMatKhauCuaToi___________Hahahahahaha_____Hiiiiii");
            using (FileStream stream = new FileStream(pathEncrypt, FileMode.OpenOrCreate))
            {
                using (StreamWriter sWriter = new StreamWriter(stream, Encoding.UTF8))
                {
                    sWriter.WriteLine(TextBox);
                    sWriter.Flush();
                    sWriter.Close();
                }
                stream.Close();
            }    
        }
        public string DencryptData()
        {
            string data;
            using (FileStream stream = new FileStream(pathEncrypt, FileMode.Open))
            {
                using (StreamReader sWriter = new StreamReader(stream, Encoding.UTF8))
                {
                    data = sWriter.ReadToEnd();
                    sWriter.Close();
                }
                stream.Close();
            }
            return Decrypt(data, "DoBanDoDuocMatKhauCuaToi___________Hahahahahaha_____Hiiiiii");
            //using (FileStream stream = new FileStream(pathDecrypt, FileMode.OpenOrCreate))
            //{
            //    using (StreamWriter sWriter = new StreamWriter(stream, Encoding.UTF8))
            //    {
            //        sWriter.WriteLine(TextBox);
            //        sWriter.Flush();
            //        sWriter.Close();
            //    }
            //    stream.Close();
            //}
        }
    }
}
