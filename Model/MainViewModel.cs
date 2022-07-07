using checkout.Entity.Vo;
using checkout.Pages;
using checkout.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace checkout.Model
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<ActivityInfoVo> searchResults;
        private ActivityInfoVo selectedActivity;
        private TicketListVo ticketList;


        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // 搜索命令
        public ICommand PerformSearch => new Command<string>(async (string query) =>
        {
            SearchResults = await DataService.GetSearchResults(query, 1);
        });



        // 立即购票
        public ICommand BuyNow => new Command(() =>
        {
            LogContent += "立即购票\r\n";
        });


        // 搜索结果

        public List<ActivityInfoVo> SearchResults
        {
            get
            {
                return searchResults;
            }
            set
            {
                searchResults = value;
                NotifyPropertyChanged();
                if (value.Count > 0) {
                    SelctedActivity = value.First();
                }
                NotifyPropertyChanged("SelctedActivity");

            }
        }

        // 选择的演出
        public ActivityInfoVo SelctedActivity
        {
            get
            {
                return selectedActivity;
            }
            set
            {
                selectedActivity = value;
                NotifyPropertyChanged();
            }
        }


        public TicketListVo TicketList
        {

            get
            {
                return ticketList;
            }
            set
            {
                ticketList = value;
                NotifyPropertyChanged();

            }
        }

        private Session session;
        public Session Session
        {
            get
            {
                return session;
            }
            set
            {
                session = value;
                NotifyPropertyChanged();

                Ticket = session.ticketList.First();
                NotifyPropertyChanged("Ticket");

            }

        }

        private TicketListItem ticket;
        public TicketListItem Ticket
        {
            get
            {
                return ticket;
            }
            set
            {
                ticket = value;
                NotifyPropertyChanged();

            }
        }

        private int buyCount = 1;

        public int BuyCount
        {
            get
            {
                return buyCount;
            }
            set
            {
                buyCount = value;
                NotifyPropertyChanged();

            }
        }

        private string logContent;
        public string LogContent
        {
            get
            {
                return logContent;
            }
            set
            {
                logContent = value;
                NotifyPropertyChanged();
            }
        }
    }
}
