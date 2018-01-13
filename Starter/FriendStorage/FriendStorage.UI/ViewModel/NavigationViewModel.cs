using System.Collections.ObjectModel;
using FriendStorage.DataAccess;
using FriendStorage.Model;

namespace FriendStorage.UI.ViewModel
{
    public class NavigationViewModel : ViewModelBase
    {
        private ObservableCollection<Friend> _friends;

        public NavigationViewModel()
        {
            Friends = new ObservableCollection<Friend>();
        }

        public ObservableCollection<Friend> Friends
        {
            get { return _friends; }
            private set
            {
                _friends = value;
                OnPropertyChanged(nameof(Friends));
            }
        }

        public void LoadFriends()
        {
            var dataService = new FileDataService();
            Friends.Clear();
            foreach (Friend friend in dataService.GetAllFriends())
            {
                Friends.Add(friend);
            }
        }
    }
}