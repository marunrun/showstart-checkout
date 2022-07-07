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




    protected List<RadioButton> historyRadio  = new List<RadioButton>();

    private void activityList_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedAct = (ActivityInfoVo)activityList.SelectedItem;


        if (selectedAct == null) return;

        DataService.GetTicketList(selectedAct.activityId, async (res) => {

            if (!res.isSuccess())
            {

                await DisplayAlert("请求失败", res.msg, "ok");

                Shell.Current.GoToAsync("login");
                return;
            }


            var first = true;

            historyRadio.ForEach(r => {
                sessionSelect.Remove(r);
            });

            historyRadio.Clear();

            res.result.sessions.ForEach((session) =>
            {
                var btn = new RadioButton();
                btn.Content = session.sessionName;
                btn.Value = session;
                if (first) { btn.IsChecked = true;first = false; }
         

                sessionSelect.Add(btn);
                historyRadio.Add(btn);

            });


        });
    }

   
}