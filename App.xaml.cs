using checkout.Exceptions;
using checkout.Services;

namespace checkout;

public partial class App : Application
{
	public App()
	{

		InitializeComponent();

		MainPage = new AppShell();
    }
}
