using checkout.Services;

namespace checkout.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{

		InitializeComponent();

        if (UserService.getUid() > 0) {
			Shell.Current.GoToAsync("main");
			return;
		}

        mobileInput.Text = UserService.getMobile();
        pwdInput.Text = UserService.getPwd();


    }

	private void loginClicked(object sender, EventArgs e)
	{
		var mobile = mobileInput.Text;
		var pwd = pwdInput.Text;

		if (string.IsNullOrWhiteSpace(mobile)) {
			this.DisplayAlert("登录失败", "账号必填","ok");
			return;
		}

        if (string.IsNullOrWhiteSpace(pwd))
        {
            this.DisplayAlert("登录失败", "密码必填", "ok");
			return;
        }

		UserService.Login(mobile, pwd);


    }
}