using checkout.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout.Notify
{
    internal class EmailNotify : BaseNotifyer
    {

        protected override void execute(string content, Action<string> action)
        {
            var client = EmailHelper.getClient();

            client.SendAsync(EmailHelper.newMessage(content));
            action("邮件发送成功");
        }
    }
}
