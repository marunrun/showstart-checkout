
using System.Windows.Forms;

namespace checkout
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.buy = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.count = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mobile = new System.Windows.Forms.TextBox();
            this.code = new System.Windows.Forms.TextBox();
            this.sendCode = new System.Windows.Forms.Button();
            this.login = new System.Windows.Forms.Button();
            this.password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pwdLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buy
            // 
            this.buy.Location = new System.Drawing.Point(24, 194);
            this.buy.Name = "buy";
            this.buy.Size = new System.Drawing.Size(75, 23);
            this.buy.TabIndex = 0;
            this.buy.Text = "购买";
            this.buy.UseVisualStyleBackColor = true;
            this.buy.Click += new System.EventHandler(this.buy_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.price,
            this.count});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(374, 63);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(183, 97);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // name
            // 
            this.name.Text = "名称";
            // 
            // price
            // 
            this.price.Text = "单价";
            // 
            // count
            // 
            this.count.Text = "库存";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(155, 193);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "滑块";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "账 号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "验证码：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobile
            // 
            this.mobile.Location = new System.Drawing.Point(75, 28);
            this.mobile.Name = "mobile";
            this.mobile.Size = new System.Drawing.Size(100, 21);
            this.mobile.TabIndex = 7;
            // 
            // code
            // 
            this.code.Location = new System.Drawing.Point(75, 113);
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(100, 21);
            this.code.TabIndex = 8;
            // 
            // sendCode
            // 
            this.sendCode.Location = new System.Drawing.Point(24, 140);
            this.sendCode.Name = "sendCode";
            this.sendCode.Size = new System.Drawing.Size(75, 23);
            this.sendCode.TabIndex = 9;
            this.sendCode.Text = "发送验证码";
            this.sendCode.UseVisualStyleBackColor = true;
            this.sendCode.Click += new System.EventHandler(this.sendCode_Click);
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(105, 140);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(75, 23);
            this.login.TabIndex = 10;
            this.login.Text = "验证码登陆";
            this.login.UseVisualStyleBackColor = true;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(240, 28);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(100, 21);
            this.password.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(193, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "密码：";
            // 
            // pwdLogin
            // 
            this.pwdLogin.Location = new System.Drawing.Point(75, 58);
            this.pwdLogin.Name = "pwdLogin";
            this.pwdLogin.Size = new System.Drawing.Size(100, 29);
            this.pwdLogin.TabIndex = 13;
            this.pwdLogin.Text = "密码登陆";
            this.pwdLogin.UseVisualStyleBackColor = true;
            this.pwdLogin.Click += new System.EventHandler(this.pwdLogin_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 247);
            this.Controls.Add(this.pwdLogin);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.login);
            this.Controls.Add(this.sendCode);
            this.Controls.Add(this.code);
            this.Controls.Add(this.mobile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.buy);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion



        private System.Windows.Forms.Button buy;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader price;
        private System.Windows.Forms.ColumnHeader count;
        private Button button1;
        private Label label1;
        private Label label2;
        private TextBox mobile;
        private TextBox code;
        private Button sendCode;
        private Button login;
        private TextBox password;
        private Label label3;
        private Button pwdLogin;
    }
}

