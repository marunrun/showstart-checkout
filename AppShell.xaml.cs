using checkout.Exceptions;
using checkout.Pages;
using checkout.Services;

namespace checkout;

public partial class AppShell : Shell
{
	public AppShell()
	{

            UserService.initToken();

			Routing.RegisterRoute("main", typeof(MainPage));

            InitializeComponent();
    }
}
