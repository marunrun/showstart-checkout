using checkout.Exceptions;
using checkout.Helper;
using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace checkout
{
    public partial class notifyConfig : Form
    {



        public notifyConfig()
        {
            InitializeComponent();


            init();

           

        }

        private void init() 
        {
            configSelectTab.SelectedIndex = int.Parse(Helpers.readIni(Notify.Factory.TAB_SELECT, "0"));


            smtpHost.Text = Helpers.readIni(EmailHelper.SMTP_HOST, "smtp.163.com");
            smtpPort.Text = Helpers.readIni(EmailHelper.SMTP_PORT, "25");

            smtpUser.Text = Helpers.readIni(EmailHelper.SMTP_USER, "");
            smtpPwd.Text = Helpers.readIni(EmailHelper.SMTP_PWD, "");


            emailAddress.Text =  Helpers.readIni(EmailHelper.EMAIL_ADDRESS,"");


            webHookIpt.Text = Helpers.readIni(Notify.WebHook.WEB_HOOK_URL, "");
            secretInpt.Text =  Helpers.readIni(Notify.WebHook.WEB_HOOK_SECRET, "");
        }

        private void notifyTest_Click(object sender, EventArgs e)
        {
            saveEmailConfig();
            saveWebHookConfig();

            var notifyer = Notify.Factory.getNotifyer();

            notifyer.send("测试通知",((res)=> {
                MessageBox.Show(res);
            }));
        }


        private void configSelectTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            Helpers.writeini(Notify.Factory.TAB_SELECT, configSelectTab.SelectedIndex.ToString());
        }

        // 保存邮箱配置
        private void emailSaveBtn_Click(object sender, EventArgs e)
        {
            saveEmailConfig();
        }

        private void saveEmailConfig() 
        {
            Helpers.writeini(EmailHelper.SMTP_HOST, smtpHost.Text);
            Helpers.writeini(EmailHelper.SMTP_PORT, smtpPort.Text);
            Helpers.writeini(EmailHelper.SMTP_USER, smtpUser.Text);
            Helpers.writeini(EmailHelper.SMTP_PWD, smtpPwd.Text);
            Helpers.writeini(EmailHelper.EMAIL_ADDRESS, emailAddress.Text);
        }

        // 保存webhook配置
        private void webHookSaveBtn_Click(object sender, EventArgs e)
        {
            saveWebHookConfig();
        }

        private void saveWebHookConfig()
        {
            Helpers.writeini(Notify.WebHook.WEB_HOOK_URL, webHookIpt.Text);
            Helpers.writeini(Notify.WebHook.WEB_HOOK_SECRET, secretInpt.Text);
        }

        private void webhookTypeChanged(object sender, EventArgs e)
        {
            if (!((RadioButton)sender).Checked)
            {
                return;
            }

            var typename = ((RadioButton)sender).Name.ToString();

            Helpers.writeini(Notify.WebHook.TYPE_SELECT, typename);
        }
    }
}
