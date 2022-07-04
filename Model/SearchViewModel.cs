using checkout.Entity.Vo;
using checkout.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace checkout.Model
{
    public class SearchViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

        public ICommand PerformSearch => new Command<string>(async (string query) =>
        {
            SearchResults = await DataService.GetSearchResults(query, 1);
        });

        private List<ActivityInfoVo> searchResults;
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
            }
        }
    }
}
