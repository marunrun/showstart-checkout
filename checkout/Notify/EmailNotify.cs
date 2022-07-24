using checkout.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout.Notify
{
    internal class EmailNotify : Notifyer
    {
        public void send(string content)
        {
            var client = EmailHelper.getClient();

            client.SendAsync(EmailHelper.newMessage(content));
        }
    }
}
