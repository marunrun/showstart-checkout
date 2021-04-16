using checkout.Exceptions;
using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace checkout
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new checkoutForm());
        }
    }
}
