
using System.Windows.Forms;

namespace checkout
{
    partial class checkoutForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mobile = new System.Windows.Forms.TextBox();
            this.code = new System.Windows.Forms.TextBox();
            this.sendCode = new System.Windows.Forms.Button();
            this.login = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pwdLogin = new System.Windows.Forms.Button();
            this.logText = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.group1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pwdLoginTab = new System.Windows.Forms.TabPage();
            this.codeLoginTab = new System.Windows.Forms.TabPage();
            this.group1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.pwdLoginTab.SuspendLayout();
            this.codeLoginTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // buy
            // 
            this.buy.Location = new System.Drawing.Point(12, 167);
            this.buy.Name = "buy";
            this.buy.Size = new System.Drawing.Size(75, 23);
            this.buy.TabIndex = 7;
            this.buy.Text = "购买";
            this.buy.UseVisualStyleBackColor = true;
            this.buy.Click += new System.EventHandler(this.buy_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(162, 167);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "滑块";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "账 号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "验证码：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobile
            // 
            this.mobile.Location = new System.Drawing.Point(70, 18);
            this.mobile.MaxLength = 11;
            this.mobile.Name = "mobile";
            this.mobile.Size = new System.Drawing.Size(100, 21);
            this.mobile.TabIndex = 1;
            this.mobile.TextChanged += new System.EventHandler(this.mobile_TextChanged);
            // 
            // code
            // 
            this.code.Location = new System.Drawing.Point(54, 16);
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(100, 21);
            this.code.TabIndex = 2;
            // 
            // sendCode
            // 
            this.sendCode.Location = new System.Drawing.Point(6, 47);
            this.sendCode.Name = "sendCode";
            this.sendCode.Size = new System.Drawing.Size(75, 23);
            this.sendCode.TabIndex = 3;
            this.sendCode.Text = "发送验证码";
            this.sendCode.UseVisualStyleBackColor = true;
            this.sendCode.Click += new System.EventHandler(this.sendCode_Click);
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(107, 47);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(75, 23);
            this.login.TabIndex = 4;
            this.login.Text = "验证码登陆";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "密码：";
            // 
            // pwdLogin
            // 
            this.pwdLogin.Location = new System.Drawing.Point(31, 41);
            this.pwdLogin.Name = "pwdLogin";
            this.pwdLogin.Size = new System.Drawing.Size(100, 29);
            this.pwdLogin.TabIndex = 3;
            this.pwdLogin.Text = "密码登陆";
            this.pwdLogin.UseVisualStyleBackColor = true;
            this.pwdLogin.Click += new System.EventHandler(this.pwdLogin_Click);
            // 
            // logText
            // 
            this.logText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logText.Location = new System.Drawing.Point(3, 17);
            this.logText.Multiline = true;
            this.logText.Name = "logText";
            this.logText.Size = new System.Drawing.Size(225, 399);
            this.logText.TabIndex = 0;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(59, 10);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(100, 21);
            this.password.TabIndex = 2;
            // 
            // group1
            // 
            this.group1.Controls.Add(this.logText);
            this.group1.Location = new System.Drawing.Point(480, 0);
            this.group1.Name = "group1";
            this.group1.Size = new System.Drawing.Size(231, 419);
            this.group1.TabIndex = 15;
            this.group1.TabStop = false;
            this.group1.Text = "日志";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.pwdLoginTab);
            this.tabControl1.Controls.Add(this.codeLoginTab);
            this.tabControl1.Location = new System.Drawing.Point(12, 45);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(196, 102);
            this.tabControl1.TabIndex = 16;
            // 
            // pwdLoginTab
            // 
            this.pwdLoginTab.Controls.Add(this.password);
            this.pwdLoginTab.Controls.Add(this.label3);
            this.pwdLoginTab.Controls.Add(this.pwdLogin);
            this.pwdLoginTab.Location = new System.Drawing.Point(4, 22);
            this.pwdLoginTab.Name = "pwdLoginTab";
            this.pwdLoginTab.Padding = new System.Windows.Forms.Padding(3);
            this.pwdLoginTab.Size = new System.Drawing.Size(188, 76);
            this.pwdLoginTab.TabIndex = 0;
            this.pwdLoginTab.Text = "密码登陆";
            this.pwdLoginTab.UseVisualStyleBackColor = true;
            // 
            // codeLoginTab
            // 
            this.codeLoginTab.Controls.Add(this.login);
            this.codeLoginTab.Controls.Add(this.sendCode);
            this.codeLoginTab.Controls.Add(this.code);
            this.codeLoginTab.Controls.Add(this.label2);
            this.codeLoginTab.Location = new System.Drawing.Point(4, 22);
            this.codeLoginTab.Name = "codeLoginTab";
            this.codeLoginTab.Padding = new System.Windows.Forms.Padding(3);
            this.codeLoginTab.Size = new System.Drawing.Size(188, 76);
            this.codeLoginTab.TabIndex = 1;
            this.codeLoginTab.Text = "验证码登陆";
            this.codeLoginTab.UseVisualStyleBackColor = true;
            // 
            // checkoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(709, 418);
            this.Controls.Add(this.mobile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.group1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buy);
            this.Name = "checkoutForm";
            this.Text = "辅助下单";
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.pwdLoginTab.ResumeLayout(false);
            this.pwdLoginTab.PerformLayout();
            this.codeLoginTab.ResumeLayout(false);
            this.codeLoginTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion



        private System.Windows.Forms.Button buy;
        private Button button1;
        private Label label1;
        private Label label2;
        private TextBox mobile;
        private TextBox code;
        private Button sendCode;
        private Button login;
        private Label label3;
        private Button pwdLogin;
        public TextBox logText;
        private TextBox password;
        private GroupBox group1;
        private TabControl tabControl1;
        private TabPage pwdLoginTab;
        private TabPage codeLoginTab;
    }
}

