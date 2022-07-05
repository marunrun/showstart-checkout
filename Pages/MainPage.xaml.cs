using checkout.Entity.Vo;
using checkout.Model;
using checkout.Services;
using System.Diagnostics;

namespace checkout.Pages;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		this.BindingContext = new MainViewModel();
	}


    private void activityList_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedAct = (ActivityInfoVo)activityList.SelectedItem;


        if (selectedAct == null) return;

        DataService.GetTicketList(selectedAct.activityId, async (res) => {

            if (!res.isSuccess() && res.state == "token.empty")
            {


                await Shell.Current.GoToAsync("login");
                return;
            }


        });
    }
}