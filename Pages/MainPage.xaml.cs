using checkout.Constants;
using checkout.Entity;
using checkout.Entity.Vo;
using checkout.Helper;
using checkout.Model;
using checkout.Services;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Linq;

namespace checkout.Pages;

public partial class MainPage : ContentPage
{

    public MainPage()
    {


        InitializeComponent();

        this.BindingContext = new MainViewModel();
    }






    protected List<RadioButton> historyRadio = new List<RadioButton>();

    private void activityList_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedAct = (ActivityInfoVo)activityList.SelectedItem;


        if (selectedAct == null) return;

        DataService.GetTicketList(selectedAct.activityId, async (res) =>
        {

            if (!res.isSuccess())
            {

                await DisplayAlert("请求失败", res.msg, "ok");

                Shell.Current.GoToAsync("login");
                return;
            }


            var first = true;

            historyRadio.ForEach(r =>
            {
                sessionSelect.Remove(r);
            });

            historyRadio.Clear();

            res.result.sessions.ForEach((session) =>
            {
                var btn = new RadioButton();
                btn.Content = session.sessionName;
                btn.Value = session;
                if (first) { btn.IsChecked = true; first = false; }


                sessionSelect.Add(btn);
                historyRadio.Add(btn);

            });


        });

        if (userSelect.ItemsSource != null)
        {
            return;

        }
        DataService.getPerfomer(async (res) =>
        {

            if (!res.isSuccess())
            {

                await DisplayAlert("用户列表请求失败", res.msg, "ok");

                Shell.Current.GoToAsync("login")
;
                return;
            }

            userSelect.ItemsSource = res.result;
        });

        DataService.getAddress(async (res) =>
        {
            if (!res.isSuccess())
            {

                await DisplayAlert("地址列表请求失败", res.msg, "ok");

                Shell.Current.GoToAsync("login")
;
                return;
            }

            addressSelect.ItemsSource = res.result;
            addressSelect.SelectedIndex = 0;
        });


    }

    private void Button_Clicked(object sender, EventArgs e)
    {

        var dto = new BuyTicketDto();
        dto.buyNum = int.Parse(buyCount.Text);
        dto.ticket = (TicketListItem)selectTicket.SelectedItem;
        dto.activity = (ActivityInfoVo)activityList.SelectedItem;

        List<UserIdInfo> userList  = new List<UserIdInfo>();

        for (int i = 0; i < userSelect.SelectedItems.Count; i++)
        {
            userList.Add((UserIdInfo)userSelect.SelectedItems[i]);
        }


        dto.userList = userList;
        dto.addressInfo = (AddressInfo)addressSelect.SelectedItem;

        OrderService.buyNow(dto,((result) => {
            if (!result.isSuccess()) {

                logContent.Text += "下单失败 "+ result.msg+" \r\n";
                return;
            }

            Dictionary<string, object> query = new Dictionary<string, object> {
                    {
                            "orderJobKey", result.result.orderJobKey }
                    };

            RequestUtil.post(Urls.ORDER_RESULT, query, new Action<string>((res2) =>
            {
                Result<object> result2 = JsonConvert.DeserializeObject<Result<object>>(res2);

                if (result2.isSuccess())
                {
                    //pickStop();
                    //notifyIcon1.Visible = true;
                    //notifyIcon1.ShowBalloonTip(10000, "抢票成功", ticket.ticketType, ToolTipIcon.Info);

                    //LogHelpers.write(ticket.ticketType + "抢票成功");
                    //AppendLogText(ticket.ticketType + "抢票成功");
                    logContent.Text += "抢票成功 " + result2.msg + " \r\n";

                    return;
                }else
                {
                    logContent.Text += "抢票失败 " + result2.msg + " \r\n";

                    return;

                }

                //buyTicketFaild(ticket, result2.msg, result2.state, failCount);
            }));
        }));
    }
}