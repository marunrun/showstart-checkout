using checkout.Exceptions;
using checkout.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace checkout.Notify
{

    interface Notifyer
    {
        void send(string content);
    }

    internal class Factory
    {

       public const string TAB_SELECT = "notify_config_select";

        public static Notifyer[] notifyMethod = new Notifyer[] {
            new EmailNotify()
        
        };


        public static Notifyer getNotifyer(int type)
        {

            if (type >= notifyMethod.Count()) {
                throw new BusinessException("对应的通知类还未实现");
            }


            return notifyMethod[type];
        }

        public static Notifyer getNotifyer()
        {

            var type = int.Parse(Helpers.readIni(TAB_SELECT, "0"));


            return getNotifyer(type);
        }
    }
}
