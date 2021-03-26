using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace checkout.Helper
{
    class Helpers
    {
        public static String Get32RandomID() {
            return System.Guid.NewGuid().ToString().Trim().Replace("-", "");
        }

        public static String GetIP() {
            string name = Dns.GetHostName();
            IPAddress[] ipadrlist = Dns.GetHostAddresses(name);
                foreach (IPAddress ipa in ipadrlist)
                {
                    if (ipa.AddressFamily == AddressFamily.InterNetwork)
                        return ipa.ToString();
                }
                return "127.0.0.1";
        }
    }
}
