using checkout.Exceptions;
using checkout.Pages;
using checkout.Services;

namespace checkout;

public partial class AppShell : Shell
{
	public AppShell()
	{
		try
		{
            UserService.initToken();

			Routing.RegisterRoute("main", typeof(MainPage));


            InitializeComponent();
		}
		catch (BusinessException  e) {
			this.DisplayAlert("┗|｀O′|┛ 嗷~~出现了一些问题", e.Message, "好吧");
			return;
		}

    }
}
