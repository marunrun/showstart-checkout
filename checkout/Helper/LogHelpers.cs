using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using static checkout.checkoutForm;

namespace checkout.Helper
{

    class LogHelpers
    {
        private static Dictionary<long, long> lockDic = new Dictionary<long, long>();


        private static string logPath = getLogPath();

        private static TextBox textBox { set; get; }


        private static string getLogPath()
        {
            return "./logs/" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
        }

 

        public static string write(string msg)
        {
            if (!Directory.Exists("./logs"))
            {
                Directory.CreateDirectory("./logs");
            }

            msg = DateTime.Now.ToString("HH:mm:ss.fff  ") + msg + "\r\n";

            Console.WriteLine(msg);
            write(msg, "");
            return msg;
        }

        private static void write(string content, string newLine)
        {
            using (FileStream fs = new FileStream(getLogPath(), FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite, 8, FileOptions.Asynchronous))
            {
                //Byte[] dataArray = System.Text.Encoding.ASCII.GetBytes(System.DateTime.Now.ToString() + content + "/r/n");  
                byte[] dataArray = Encoding.Default.GetBytes(content + newLine);
                bool flag = true;
                long slen = dataArray.Length;
                long len = 0;
                while (flag)
                {
                    try
                    {
                        if (len >= fs.Length)
                        {
                            fs.Lock(len, slen);
                            lockDic[len] = slen;
                            flag = false;
                        }
                        else
                        {
                            len = fs.Length;
                        }
                    }
                    catch (Exception ex)
                    {
                        while (!lockDic.ContainsKey(len))
                        {
                            len += lockDic[len];
                        }
                    }
                }
                fs.Seek(len, SeekOrigin.Begin);
                fs.Write(dataArray, 0, dataArray.Length);
                fs.Close();
            }
        }
    }
}
