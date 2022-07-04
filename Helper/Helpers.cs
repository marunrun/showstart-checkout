using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;



namespace checkout.Helper
{
    class Helpers
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);


        private static string SECTION = "userInfo";

        private static string FILEPATH = "./Config.ini";

        // 随机32位uuid
        public static String Get32RandomID()
        {
            return System.Guid.NewGuid().ToString().Trim().Replace("-", "");
        }

        // 获取ip
        public static String GetIP()
        {
            string name = Dns.GetHostName();
            IPAddress[] ipadrlist = Dns.GetHostAddresses(name);
            foreach (IPAddress ipa in ipadrlist)
            {
                if (ipa.AddressFamily == AddressFamily.InterNetwork)
                    return ipa.ToString();
            }
            return "127.0.0.1";
        }

        // 写入ini
        public static void writeini(string key, string value)
        {
            WritePrivateProfileString(SECTION, key, value, FILEPATH);
        }

        // 读取ini
        public static string readIni(string key, string defaultValue)
        {
            StringBuilder buffer = new StringBuilder();
            GetPrivateProfileString(SECTION, key, defaultValue, buffer, 255, FILEPATH);
            return buffer.ToString();
        }


        //DateTime类型转换为时间戳(毫秒值)
        public static long DateToTicks(DateTime time)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)); // 当地时区


            return (long)time.Subtract(startTime).TotalMilliseconds;
        }

        public static DateTime ticksToDate(long cc) 
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));//当地时区  
            return  startTime.AddMilliseconds(cc);
        }

        public static long CurrentTimeStamp()
        {
            return DateToTicks(DateTime.Now);
        }

   
        public static string getRandom()
        {
            char[] charArray = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
            String str = "";
            int i2 = 0;
            while (i2 < 8)
            {
                char c = charArray[(new Random().Next(0, 61))];
                if (str.Contains(c.ToString()))
                {
                    i2--;
                }
                else
                {
                    str = str + c;
                }
                i2++;
            }
            return str;
        }

        /// <summary>
        /// AES加密
        /// </summary>
        /// <returns></returns>
        public static string AesEncrypt(string key, string str)
        {
            if (string.IsNullOrEmpty(str)) return null;
            byte[] toEncryptArray = Encoding.UTF8.GetBytes(str);

            RijndaelManaged rm = new RijndaelManaged
            {
                Key = Encoding.UTF8.GetBytes(key),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            ICryptoTransform cTransform = rm.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            var base64String = Convert.ToBase64String(resultArray, 0, resultArray.Length);
            return base64String;
        }

        //md5
        public static string Md5(string str)
        {
            Console.WriteLine(str);
            MD5 md5 = MD5.Create(); //实例化一个md5对像
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] digest = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder stringBuilder = new StringBuilder();
            for (var i = 0; i < digest.Length; ++i)
            {
                if ((digest[i] & 255).ToString("X2").Length == 1)
                {
                    stringBuilder.Append("0");
                }
                stringBuilder.Append((digest[i] & 255).ToString("X2"));
            }
            return stringBuilder.ToString().ToLower();
        }



        public static string transtoPath(string str,string str2) 
        {
            String str3 = "00";
            if (!String.IsNullOrEmpty(str))
            {
                try
                {
                    String b = base62(long.Parse(str));
                    str3 = convert(2, b);
                }
                catch (Exception unused)
                {
                }
            }

            String stringPlus = "" + str3;

            String str4 = "0000";
            if (!String.IsNullOrEmpty(str2))
            {
                try
                {
                    String b2 = base62(long.Parse(str2));
                    str4 = convert(4, b2);
                }
                catch (Exception unused2)
                {
                }
            }
            String stringPlus2 = stringPlus+ str4;
            String C0 = readIni("userId","");
            String str5 = "000000";
            if (!String.IsNullOrEmpty(C0))
            {
                try
                {
                    String b3 = base62(long.Parse(C0));
                    str5 = convert(6, b3);
                }
                catch (Exception unused3)
                {
                }
            }

            return stringPlus2 +  str5;
        }


        private const string base62Charset = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string base62(long j2) 
        {
            if (j2 >= 1)
            {
                StringBuilder sb = new StringBuilder();
                while (j2 > 0)
                {
                    sb.Append(base62Charset.ElementAt((int)(j2 % 62)));
                    j2 /= 62;
                }
                char[] arr =  sb.ToString().ToCharArray();
                Array.Reverse(arr);
                return new string(arr);

            }

            throw new InvalidProgramException("base62 长度问题");
        }

        private static string convert(int i2, String str)
        {
            int i3 = 0;
            if (!String.IsNullOrEmpty(str))
            {
                if (str.Length < i2)
                {
                    StringBuilder sb = new StringBuilder();
                    int length = i2 - str.Length;
                    while (i3 < length)
                    {
                        i3++;
                        sb.Append("0");
                    }
                    sb.Append(str);
                    str = sb.ToString();
                }
                return str;
            }
            StringBuilder sb2 = new StringBuilder();
            while (i3 < i2)
            {
                i3++;
                sb2.Append("0");
            }
            String sb3 = sb2.ToString();
            return sb3;
        }



    }
}
