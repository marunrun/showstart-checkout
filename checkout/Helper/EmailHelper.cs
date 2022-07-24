using checkout.Exceptions;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace checkout.Helper
{
    public class EmailHelper
    {

        private static SmtpClient client;

        public const string SMTP_HOST = "smtp_host";
        public const string SMTP_PORT = "smtp_port";
        public const string SMTP_USER = "smtp_user";
        public const string SMTP_PWD = "smtp_pwd";
        public const string EMAIL_ADDRESS = "email_addr";


        public static SmtpClient getClient(bool refresh = false)
        {

            if (!refresh && EmailHelper.client != null)
            {
                return EmailHelper.client;
            }


            var host = Helpers.readIni(SMTP_HOST, "");
            var port = int.Parse(Helpers.readIni(SMTP_PORT, "25"));
            if (string.IsNullOrEmpty(host))
            {
                throw new BusinessException("未设置邮箱SMTP ");
            }


            var client = new SmtpClient();

            client.Connect(host, port, false);

            // Note: only needed if the SMTP server requires authentication
            var user = Helpers.readIni(SMTP_USER, "");
            var pwd = Helpers.readIni(SMTP_PWD, "");


            client.Authenticate(user, pwd);
            EmailHelper.client = client;
            return client;
        }

        public static MimeMessage newMessage(string content) 
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("秀动辅助", Helpers.readIni(SMTP_USER,"")));
            message.To.Add(new MailboxAddress("", Helpers.readIni(EMAIL_ADDRESS,"")));
            message.Subject = "秀动辅助通知";

            message.Body = new TextPart("plain")
            {
                Text = content
            };

            return message;
        }
    }
}
