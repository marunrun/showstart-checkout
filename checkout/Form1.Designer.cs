
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
            this.components = new System.ComponentModel.Container();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.userIdSelector = new System.Windows.Forms.ComboBox();
            this.userIdInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.addressSelector = new System.Windows.Forms.ComboBox();
            this.addressInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.refreshInfo = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.searchSelector = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.activityComboBox = new System.Windows.Forms.ComboBox();
            this.activityInfoVoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchBtn = new System.Windows.Forms.Button();
            this.searchTxt = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pickUpBtn = new System.Windows.Forms.Button();
            this.buyTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.couponList = new System.Windows.Forms.ComboBox();
            this.couponInfoVoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.buyTimeBtn = new System.Windows.Forms.Button();
            this.buyNowBtn = new System.Windows.Forms.Button();
            this.remainTicket = new System.Windows.Forms.Label();
            this.ticketList = new System.Windows.Forms.ComboBox();
            this.ticketListItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userSessionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ticketListVoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buyTimer = new System.Windows.Forms.Timer(this.components);
            this.pickUpTimer = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.group1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.pwdLoginTab.SuspendLayout();
            this.codeLoginTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userIdInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressInfoBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.activityInfoVoBindingSource)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.couponInfoVoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticketListItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userSessionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticketListVoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "账 号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "验证码：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobile
            // 
            this.mobile.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mobile.Location = new System.Drawing.Point(78, 23);
            this.mobile.MaxLength = 11;
            this.mobile.Name = "mobile";
            this.mobile.Size = new System.Drawing.Size(100, 23);
            this.mobile.TabIndex = 1;
            // 
            // code
            // 
            this.code.Location = new System.Drawing.Point(54, 16);
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(100, 23);
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
            this.label3.Size = new System.Drawing.Size(49, 14);
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
            this.password.Size = new System.Drawing.Size(100, 23);
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
            this.tabControl1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(12, 51);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(248, 120);
            this.tabControl1.TabIndex = 16;
            // 
            // pwdLoginTab
            // 
            this.pwdLoginTab.Controls.Add(this.password);
            this.pwdLoginTab.Controls.Add(this.label3);
            this.pwdLoginTab.Controls.Add(this.pwdLogin);
            this.pwdLoginTab.Location = new System.Drawing.Point(4, 24);
            this.pwdLoginTab.Name = "pwdLoginTab";
            this.pwdLoginTab.Padding = new System.Windows.Forms.Padding(3);
            this.pwdLoginTab.Size = new System.Drawing.Size(240, 92);
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
            this.codeLoginTab.Location = new System.Drawing.Point(4, 24);
            this.codeLoginTab.Name = "codeLoginTab";
            this.codeLoginTab.Padding = new System.Windows.Forms.Padding(3);
            this.codeLoginTab.Size = new System.Drawing.Size(240, 92);
            this.codeLoginTab.TabIndex = 1;
            this.codeLoginTab.Text = "验证码登陆";
            this.codeLoginTab.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.userIdSelector);
            this.groupBox1.Location = new System.Drawing.Point(266, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 50);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "常用观影人";
            // 
            // userIdSelector
            // 
            this.userIdSelector.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.userIdInfoBindingSource, "documentNumber", true));
            this.userIdSelector.DataSource = this.userIdInfoBindingSource;
            this.userIdSelector.DisplayMember = "name";
            this.userIdSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userIdSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userIdSelector.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userIdSelector.FormattingEnabled = true;
            this.userIdSelector.Location = new System.Drawing.Point(3, 17);
            this.userIdSelector.Name = "userIdSelector";
            this.userIdSelector.Size = new System.Drawing.Size(202, 22);
            this.userIdSelector.TabIndex = 21;
            this.userIdSelector.ValueMember = "documentNumber";
            // 
            // userIdInfoBindingSource
            // 
            this.userIdInfoBindingSource.DataSource = typeof(checkout.Entity.Vo.UserIdInfo);
            // 
            // addressSelector
            // 
            this.addressSelector.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.addressInfoBindingSource, "id", true));
            this.addressSelector.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.addressInfoBindingSource, "address", true));
            this.addressSelector.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.addressInfoBindingSource, "id", true));
            this.addressSelector.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.addressInfoBindingSource, "address", true));
            this.addressSelector.DataSource = this.addressInfoBindingSource;
            this.addressSelector.DisplayMember = "address";
            this.addressSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addressSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addressSelector.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.addressSelector.FormattingEnabled = true;
            this.addressSelector.Location = new System.Drawing.Point(3, 17);
            this.addressSelector.Name = "addressSelector";
            this.addressSelector.Size = new System.Drawing.Size(199, 22);
            this.addressSelector.TabIndex = 19;
            this.addressSelector.ValueMember = "id";
            // 
            // addressInfoBindingSource
            // 
            this.addressInfoBindingSource.DataSource = typeof(checkout.Entity.Vo.AddressInfo);
            // 
            // refreshInfo
            // 
            this.refreshInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.refreshInfo.Location = new System.Drawing.Point(269, 144);
            this.refreshInfo.Name = "refreshInfo";
            this.refreshInfo.Size = new System.Drawing.Size(205, 23);
            this.refreshInfo.TabIndex = 20;
            this.refreshInfo.Text = "刷新信息";
            this.refreshInfo.UseVisualStyleBackColor = true;
            this.refreshInfo.Click += new System.EventHandler(this.refreshInfo_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.addressSelector);
            this.groupBox2.Location = new System.Drawing.Point(269, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(205, 50);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "地址信息";
            // 
            // searchSelector
            // 
            this.searchSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchSelector.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.searchSelector.FormattingEnabled = true;
            this.searchSelector.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.searchSelector.Location = new System.Drawing.Point(6, 20);
            this.searchSelector.Name = "searchSelector";
            this.searchSelector.Size = new System.Drawing.Size(82, 22);
            this.searchSelector.TabIndex = 23;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.activityComboBox);
            this.groupBox3.Controls.Add(this.searchBtn);
            this.groupBox3.Controls.Add(this.searchTxt);
            this.groupBox3.Controls.Add(this.searchSelector);
            this.groupBox3.Location = new System.Drawing.Point(12, 176);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(465, 96);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "演出搜索";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(6, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 27;
            this.label4.Text = "选择演出：";
            // 
            // activityComboBox
            // 
            this.activityComboBox.DataSource = this.activityInfoVoBindingSource;
            this.activityComboBox.DisplayMember = "MyTitle";
            this.activityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.activityComboBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.activityComboBox.FormattingEnabled = true;
            this.activityComboBox.Location = new System.Drawing.Point(94, 64);
            this.activityComboBox.Name = "activityComboBox";
            this.activityComboBox.Size = new System.Drawing.Size(365, 22);
            this.activityComboBox.TabIndex = 26;
            this.activityComboBox.ValueMember = "activityId";
            this.activityComboBox.SelectionChangeCommitted += new System.EventHandler(this.activityChange);
            // 
            // activityInfoVoBindingSource
            // 
            this.activityInfoVoBindingSource.DataSource = typeof(checkout.Entity.Vo.ActivityInfoVo);
            // 
            // searchBtn
            // 
            this.searchBtn.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.searchBtn.Location = new System.Drawing.Point(384, 20);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(75, 23);
            this.searchBtn.TabIndex = 25;
            this.searchBtn.Text = "点击搜索";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // searchTxt
            // 
            this.searchTxt.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.searchTxt.ImeMode = System.Windows.Forms.ImeMode.On;
            this.searchTxt.Location = new System.Drawing.Point(94, 20);
            this.searchTxt.Name = "searchTxt";
            this.searchTxt.Size = new System.Drawing.Size(231, 23);
            this.searchTxt.TabIndex = 24;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pickUpBtn);
            this.groupBox4.Controls.Add(this.buyTimePicker);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.couponList);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.buyTimeBtn);
            this.groupBox4.Controls.Add(this.buyNowBtn);
            this.groupBox4.Controls.Add(this.remainTicket);
            this.groupBox4.Controls.Add(this.ticketList);
            this.groupBox4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(12, 295);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(465, 100);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "选票";
            // 
            // pickUpBtn
            // 
            this.pickUpBtn.Location = new System.Drawing.Point(94, 68);
            this.pickUpBtn.Name = "pickUpBtn";
            this.pickUpBtn.Size = new System.Drawing.Size(75, 23);
            this.pickUpBtn.TabIndex = 9;
            this.pickUpBtn.Text = "开始捡漏";
            this.pickUpBtn.UseVisualStyleBackColor = true;
            this.pickUpBtn.Click += new System.EventHandler(this.pickUpBtn_Click);
            // 
            // buyTimePicker
            // 
            this.buyTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.buyTimePicker.Location = new System.Drawing.Point(254, 68);
            this.buyTimePicker.Name = "buyTimePicker";
            this.buyTimePicker.ShowUpDown = true;
            this.buyTimePicker.Size = new System.Drawing.Size(78, 23);
            this.buyTimePicker.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(257, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 7;
            this.label5.Text = "优惠券";
            // 
            // couponList
            // 
            this.couponList.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.couponInfoVoBindingSource, "id", true));
            this.couponList.DataSource = this.couponInfoVoBindingSource;
            this.couponList.DisplayMember = "price";
            this.couponList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.couponList.FormattingEnabled = true;
            this.couponList.Location = new System.Drawing.Point(306, 22);
            this.couponList.Name = "couponList";
            this.couponList.Size = new System.Drawing.Size(156, 22);
            this.couponList.TabIndex = 6;
            this.couponList.ValueMember = "id";
            // 
            // couponInfoVoBindingSource
            // 
            this.couponInfoVoBindingSource.DataSource = typeof(checkout.Entity.Vo.CouponInfoVo);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(185, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 14);
            this.label7.TabIndex = 4;
            this.label7.Text = "选择时间：";
            // 
            // buyTimeBtn
            // 
            this.buyTimeBtn.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buyTimeBtn.Location = new System.Drawing.Point(338, 68);
            this.buyTimeBtn.Name = "buyTimeBtn";
            this.buyTimeBtn.Size = new System.Drawing.Size(121, 23);
            this.buyTimeBtn.TabIndex = 3;
            this.buyTimeBtn.Text = "定时自动购票";
            this.buyTimeBtn.UseVisualStyleBackColor = true;
            this.buyTimeBtn.Click += new System.EventHandler(this.buyTimeBtn_Click);
            // 
            // buyNowBtn
            // 
            this.buyNowBtn.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buyNowBtn.Location = new System.Drawing.Point(6, 68);
            this.buyNowBtn.Name = "buyNowBtn";
            this.buyNowBtn.Size = new System.Drawing.Size(75, 23);
            this.buyNowBtn.TabIndex = 2;
            this.buyNowBtn.Text = "立即购票";
            this.buyNowBtn.UseVisualStyleBackColor = true;
            this.buyNowBtn.Click += new System.EventHandler(this.buyNowBtn_Click);
            // 
            // remainTicket
            // 
            this.remainTicket.AutoSize = true;
            this.remainTicket.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.remainTicket.Location = new System.Drawing.Point(232, 27);
            this.remainTicket.Name = "remainTicket";
            this.remainTicket.Size = new System.Drawing.Size(0, 14);
            this.remainTicket.TabIndex = 1;
            // 
            // ticketList
            // 
            this.ticketList.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.ticketListItemBindingSource, "ticketId", true));
            this.ticketList.DataSource = this.ticketListItemBindingSource;
            this.ticketList.DisplayMember = "text";
            this.ticketList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ticketList.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ticketList.FormattingEnabled = true;
            this.ticketList.Location = new System.Drawing.Point(8, 22);
            this.ticketList.Name = "ticketList";
            this.ticketList.Size = new System.Drawing.Size(203, 22);
            this.ticketList.TabIndex = 0;
            this.ticketList.ValueMember = "ticketId";
            this.ticketList.SelectedIndexChanged += new System.EventHandler(this.ticketChange);
            // 
            // ticketListItemBindingSource
            // 
            this.ticketListItemBindingSource.DataSource = typeof(checkout.Entity.Vo.TicketListItem);
            // 
            // userSessionBindingSource
            // 
            this.userSessionBindingSource.DataSource = typeof(checkout.Entity.Vo.UserSession);
            // 
            // ticketListVoBindingSource
            // 
            this.ticketListVoBindingSource.DataSource = typeof(checkout.Entity.Vo.TicketListVo);
            // 
            // buyTimer
            // 
            this.buyTimer.Interval = 10;
            this.buyTimer.Tick += new System.EventHandler(this.buyTimer_Tick);
            // 
            // pickUpTimer
            // 
            this.pickUpTimer.Tick += new System.EventHandler(this.pickUpTimer_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(106, 266);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // checkoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(709, 418);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.refreshInfo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.mobile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.group1);
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Name = "checkoutForm";
            this.Text = "秀动辅助";
            this.Load += new System.EventHandler(this.makeToken);
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.pwdLoginTab.ResumeLayout(false);
            this.pwdLoginTab.PerformLayout();
            this.codeLoginTab.ResumeLayout(false);
            this.codeLoginTab.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userIdInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressInfoBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.activityInfoVoBindingSource)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.couponInfoVoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticketListItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userSessionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticketListVoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private GroupBox groupBox1;
        private ComboBox addressSelector;
        private BindingSource addressInfoBindingSource;
        private Button refreshInfo;
        private ComboBox userIdSelector;
        private BindingSource userIdInfoBindingSource;
        private GroupBox groupBox2;
        private ComboBox searchSelector;
        private GroupBox groupBox3;
        private TextBox searchTxt;
        private Button searchBtn;
        private Label label4;
        private ComboBox activityComboBox;
        private GroupBox groupBox4;
        private Label label7;
        private Button buyTimeBtn;
        private Button buyNowBtn;
        private Label remainTicket;
        private ComboBox ticketList;
        private BindingSource activityInfoVoBindingSource;
        private BindingSource userSessionBindingSource;
        private BindingSource ticketListItemBindingSource;
        private BindingSource ticketListVoBindingSource;
        private ComboBox couponList;
        private Label label5;
        private BindingSource couponInfoVoBindingSource;
        private Timer buyTimer;
        private DateTimePicker buyTimePicker;
        private Button pickUpBtn;
        private Timer pickUpTimer;
        private Button button1;
    }
}

