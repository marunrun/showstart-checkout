﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
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
        public static long DateToTicks(DateTime? time)
        {
            return ((time.HasValue ? time.Value.Ticks : DateTime.Parse("1990-01-01").Ticks) - 621355968000000000) / 10000;
        }

        //时间戳(毫秒值)String转换为DateTime类型转换
        public static DateTime TicksToDate(string time)
        {
            return new DateTime((Convert.ToInt64(time) * 10000) + 621355968000000000);
        }
    }
}
