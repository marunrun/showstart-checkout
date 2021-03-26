using checkout.Entity;
using checkout.Helper;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace checkout
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            initListView();
        }

        protected void initListView()
        {
            this.listView1.BeginUpdate();
            foreach (Product product in Depot.products.Values)
            {
                ListViewItem item = new ListViewItem();
                item.Text = product.name;
                item.SubItems.Add(product.price.ToString());
                item.SubItems.Add(product.count.ToString());
                this.listView1.Items.Add(item);
            }
            this.listView1.EndUpdate();
        }

        private void buy_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = this.listView1.SelectedItems;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("是否确认购买");
            foreach (ListViewItem item in selectedItems)
            {
                stringBuilder.Append($"{item.Text} ");
            }
            stringBuilder.Append("？");

            if (MessageBox.Show(stringBuilder.ToString(), "是否确认购买", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");

            }
        }


        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void sendCode_Click(object sender, EventArgs e)
        {
            String userMobile = mobile.Text;


        }

        private void pwdLogin_Click(object sender, EventArgs e)
        {
            String userMobile = mobile.Text;
            
            if (userMobile.Length  == 0 || userMobile.Length != 11) {
                MessageBox.Show("手机号格式错误");
                return;
            }
            String pwd = password.Text;
            if (pwd.Length == 0 )
            {
                MessageBox.Show("密码不得为空");
                return;
            }
            LoginData loginData = new LoginData();
            loginData.areaCode = "86_CN";
            loginData.cityCode = "571";
            loginData.deviceType = 4;
            loginData.jsessionId = Helpers.Get32RandomID();
            loginData.latitude = 30.275146;
            loginData.longitude = 120.12643;
            loginData.loginIp = Helpers.GetIP();
            loginData.name = userMobile;
            loginData.password = pwd;

            string res = RequestUtil.Sign(JsonConvert.SerializeObject(loginData));
            Console.WriteLine(res);
        }
    }
}
