using System.Collections.ObjectModel;
using FriendStorage.Model;
using FriendStorage.UI.DataProviders;

namespace FriendStorage.UI.ViewModel
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private readonly INavigationDataProvider _dataProvider;
        private ObservableCollection<LookupItem> _friends;

        public ObservableCollection<LookupItem> Friends
        {
            get { return _friends; }
            private set
            {
                _friends = value;
                OnPropertyChanged(nameof(Friends));
            }
        }

        public NavigationViewModel(INavigationDataProvider dataProvider)
        {
            _friends = new ObservableCollection<LookupItem>();
            _dataProvider = dataProvider;
        }

        public void LoadFriends()
        {
            Friends.Clear();
            foreach (var friend in _dataProvider.GetAllFriends())
            {
                Friends.Add(friend);
            }
        }
    }
}