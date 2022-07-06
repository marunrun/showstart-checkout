using checkout.Exceptions;
using checkout.Pages;
using checkout.Services;

namespace checkout;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        Routing.RegisterRoute("login", typeof(LoginPage));
        Routing.RegisterRoute("main", typeof(MainPage));

		MainPage = new AppShell();
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        if(MainPage == null){
            MainPage = new AppShell();
        }
        return base.CreateWindow(activationState);
    }

}
