using checkout.Services;

namespace checkout.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{

		InitializeComponent();

        mobileInput.Text = UserService.getMobile();
        pwdInput.Text = UserService.getPwd();
    }

	private async void loginClicked(object sender, EventArgs e)
	{
		var mobile = mobileInput.Text;
		var pwd = pwdInput.Text;

		if (string.IsNullOrWhiteSpace(mobile)) {
			await this.DisplayAlert("登录失败", "账号必填","ok");
			return;
		}

        if (string.IsNullOrWhiteSpace(pwd))
        {
            await this.DisplayAlert("登录失败", "密码必填", "ok");
			return;
        }

		UserService.Login(mobile, pwd);
        await Shell.Current.GoToAsync("main");
    }
}