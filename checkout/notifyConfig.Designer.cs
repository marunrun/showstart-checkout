namespace checkout
{
    partial class notifyConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.configSelectTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.emailAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.smtpPwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.smtpUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.smtpHost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.webHookIpt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.notifyTest = new System.Windows.Forms.Button();
            this.emailSaveBtn = new System.Windows.Forms.Button();
            this.webHookSaveBtn = new System.Windows.Forms.Button();
            this.smtpPort = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.configSelectTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // configSelectTab
            // 
            this.configSelectTab.Controls.Add(this.tabPage1);
            this.configSelectTab.Controls.Add(this.tabPage2);
            this.configSelectTab.Location = new System.Drawing.Point(12, 38);
            this.configSelectTab.Name = "configSelectTab";
            this.configSelectTab.SelectedIndex = 0;
            this.configSelectTab.Size = new System.Drawing.Size(585, 297);
            this.configSelectTab.TabIndex = 0;
            this.configSelectTab.SelectedIndexChanged += new System.EventHandler(this.configSelectTab_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.smtpPort);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.emailSaveBtn);
            this.tabPage1.Controls.Add(this.emailAddress);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.smtpPwd);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.smtpUser);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.smtpHost);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(577, 264);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "邮箱";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // emailAddress
            // 
            this.emailAddress.Location = new System.Drawing.Point(160, 180);
            this.emailAddress.Name = "emailAddress";
            this.emailAddress.Size = new System.Drawing.Size(243, 26);
            this.emailAddress.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "收件人";
            // 
            // smtpPwd
            // 
            this.smtpPwd.Location = new System.Drawing.Point(160, 136);
            this.smtpPwd.Name = "smtpPwd";
            this.smtpPwd.Size = new System.Drawing.Size(243, 26);
            this.smtpPwd.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "密码";
            // 
            // smtpUser
            // 
            this.smtpUser.Location = new System.Drawing.Point(160, 104);
            this.smtpUser.Name = "smtpUser";
            this.smtpUser.Size = new System.Drawing.Size(243, 26);
            this.smtpUser.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "账号";
            // 
            // smtpHost
            // 
            this.smtpHost.Location = new System.Drawing.Point(160, 24);
            this.smtpHost.Name = "smtpHost";
            this.smtpHost.Size = new System.Drawing.Size(243, 26);
            this.smtpHost.TabIndex = 1;
            this.smtpHost.Text = "smtp.163.com";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "SMTP服务器";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.webHookSaveBtn);
            this.tabPage2.Controls.Add(this.webHookIpt);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(577, 264);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "webHook";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // webHookIpt
            // 
            this.webHookIpt.Location = new System.Drawing.Point(86, 57);
            this.webHookIpt.Name = "webHookIpt";
            this.webHookIpt.Size = new System.Drawing.Size(440, 26);
            this.webHookIpt.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "URL";
            // 
            // notifyTest
            // 
            this.notifyTest.Location = new System.Drawing.Point(12, 368);
            this.notifyTest.Name = "notifyTest";
            this.notifyTest.Size = new System.Drawing.Size(177, 41);
            this.notifyTest.TabIndex = 1;
            this.notifyTest.Text = "测试通知";
            this.notifyTest.UseVisualStyleBackColor = true;
            this.notifyTest.Click += new System.EventHandler(this.notifyTest_Click);
            // 
            // emailSaveBtn
            // 
            this.emailSaveBtn.Location = new System.Drawing.Point(17, 225);
            this.emailSaveBtn.Name = "emailSaveBtn";
            this.emailSaveBtn.Size = new System.Drawing.Size(101, 33);
            this.emailSaveBtn.TabIndex = 8;
            this.emailSaveBtn.Text = "保存配置";
            this.emailSaveBtn.UseVisualStyleBackColor = true;
            this.emailSaveBtn.Click += new System.EventHandler(this.emailSaveBtn_Click);
            // 
            // webHookSaveBtn
            // 
            this.webHookSaveBtn.Location = new System.Drawing.Point(25, 206);
            this.webHookSaveBtn.Name = "webHookSaveBtn";
            this.webHookSaveBtn.Size = new System.Drawing.Size(101, 33);
            this.webHookSaveBtn.TabIndex = 9;
            this.webHookSaveBtn.Text = "保存配置";
            this.webHookSaveBtn.UseVisualStyleBackColor = true;
            this.webHookSaveBtn.Click += new System.EventHandler(this.webHookSaveBtn_Click);
            // 
            // smtpPort
            // 
            this.smtpPort.Location = new System.Drawing.Point(160, 56);
            this.smtpPort.Name = "smtpPort";
            this.smtpPort.Size = new System.Drawing.Size(243, 26);
            this.smtpPort.TabIndex = 10;
            this.smtpPort.Text = "25";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "SMTP服务器端口";
            // 
            // notifyConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 441);
            this.Controls.Add(this.notifyTest);
            this.Controls.Add(this.configSelectTab);
            this.Name = "notifyConfig";
            this.Text = "消息通知配置";
            this.configSelectTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl configSelectTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox smtpPwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox smtpUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox smtpHost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox webHookIpt;
        private System.Windows.Forms.TextBox emailAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button notifyTest;
        private System.Windows.Forms.Button emailSaveBtn;
        private System.Windows.Forms.Button webHookSaveBtn;
        private System.Windows.Forms.TextBox smtpPort;
        private System.Windows.Forms.Label label6;
    }
}