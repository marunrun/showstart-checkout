using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace checkout.Helper
{

    class LogHelpers
    {

        private static string logPath = getLogPath();

        private static TextBox textBox { set; get; }


        private static string getLogPath()
        {
            return "./logs/" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
        }

        public static string write(string msg, TextBox textBox)
        {
            string v = write(msg);
            textBox.AppendText(v);
            return v;
        }

        public static string write(string msg)
        {
            if (!Directory.Exists("./logs"))
            {
                Directory.CreateDirectory("./logs");
            }

            FileStream fileStream;

            if (!File.Exists(logPath))
            {
                fileStream = File.Create(logPath);
            }
            else
            {
                fileStream = File.OpenWrite(logPath);
            }

            msg = DateTime.Now.ToString("HH:mm:ss  ") + msg + "\r\n";

            byte[] vs = new UTF8Encoding(true).GetBytes(msg);
            fileStream.Write(vs, 0, vs.Length);

            fileStream.Close();
            fileStream.Dispose();
            return msg;
        }
    }
}
