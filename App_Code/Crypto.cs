using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace StaticFunction
{
    public class Crypto
    {
        public Crypto()
        {

        }

        public static string EncryptMessage(string key, string message)
        {
            byte[] hkey = Encoding.Unicode.GetBytes(key);
            byte[] hashKey = ComputeHash(hkey);
            return Convert.ToBase64String(Encrypt(hashKey, Encoding.Unicode.GetBytes(message)));
        }

        public static string DecryptMessage(string key, string message)
        {
            byte[] hkey = Encoding.Unicode.GetBytes(key);
            byte[] hashKey = ComputeHash(hkey);
            return Encoding.Unicode.GetString(Decrypt(hashKey, Convert.FromBase64String(message)));
        }

        public static string CheckSum(string cardNo)
        {
            string result = string.Empty;
            string resultCard = string.Empty;
            string buf = string.Empty;
            int buf1, buf2, buf3;

            // Convert to Hexadecimal ToString("X") 
            buf = StringCrc(cardNo).ToString("X");

            //Get Last 4 Byte
            resultCard = buf.Substring(buf.Length - 4, 4).ToUpper();

            buf1 = int.Parse(resultCard.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            buf2 = int.Parse(resultCard.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            buf3 = (buf1 ^ buf2);
            result = PutZero(Convert.ToInt32(buf3 % 100).ToString(), 2, true);
            return result;
        }

        #region Internal Function EncryptMessage and DescryptMessage

        private static byte[] ComputeHash(byte[] key)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hash = md5.ComputeHash(key);
            return hash;
        }

        private static byte[] Decrypt(byte[] key, byte[] message)
        {
            byte[] result = null;
            TripleDES tripleDes = new TripleDESCryptoServiceProvider();
            tripleDes.Mode = CipherMode.CBC;
            tripleDes.Padding = PaddingMode.PKCS7;

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, tripleDes.CreateDecryptor(key, new byte[8]), CryptoStreamMode.Write))
                {
                    cs.Write(message, 0, message.Length);
                    cs.FlushFinalBlock();
                    ms.Capacity = (int)ms.Length;

                    //byte[] plain = ms.GetBuffer();
                    result = ms.GetBuffer();

                }
            }
            return result;
        }

        private static byte[] Encrypt(byte[] key, byte[] message)
        {
            byte[] result = null;
            TripleDES tripleDes = new TripleDESCryptoServiceProvider();
            tripleDes.Mode = CipherMode.CBC;
            tripleDes.Padding = PaddingMode.PKCS7;

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, tripleDes.CreateEncryptor(key, new byte[8]), System.Security.Cryptography.CryptoStreamMode.Write))
                {
                    cs.Write(message, 0, message.Length);
                    cs.FlushFinalBlock();
                    ms.Capacity = (int)ms.Length;

                    //byte[] cipher = ms.GetBuffer();
                    result = ms.GetBuffer();
                }
            }
            return result;
        }

        #endregion Internal Function

        #region Internal Function Calculate CheckSum

        private static int StringCrc(string s)
        {
            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                ByteCrc(Convert.ToInt32(s[i]), ref result);
            }
            return result;

        }

        private static void ByteCrc(int data, ref int crc)
        {
            crc = crc ^ (data << 8);
            for (int i = 0; i < 8; i++)
            {
                int checkCRC = crc & int.Parse("8000", System.Globalization.NumberStyles.HexNumber);
                if (checkCRC != 0)
                {
                    crc = crc << 1;
                    crc = crc ^ 0x1021;
                }
                else
                {
                    crc = crc << 1;
                }
            }
        }

        private static string PutZero(string strNo, int maxLen, bool status)
        {
            int lenStrNo = strNo.Length;
            if (lenStrNo != maxLen)
            {
                do
                {
                    if (status)
                    {
                        strNo = "0" + strNo;

                    }
                    else
                    {
                        strNo += "0";
                    }
                    lenStrNo++;
                }
                while (lenStrNo < maxLen);
            }

            return strNo;
        }

        #endregion 
    }
}
