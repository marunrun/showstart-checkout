using checkout.Exceptions;
using checkout.Services;

namespace checkout;

public partial class App : Application
{
	public App()
	{

		try
		{


			InitializeComponent();

			MainPage = new AppShell();
		} catch (Exception ex) {
            
	
        }

    }

}
