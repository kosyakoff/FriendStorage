using System.Collections.ObjectModel;
using FriendStorage.Model;
using FriendStorage.UI.DataProviders;
using Prism.Events;

namespace FriendStorage.UI.ViewModel
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        #region Fields

        private readonly INavigationDataProvider _dataProvider;
        private ObservableCollection<NavigationItemViewModel> _friends;
        private IEventAggregator _eventAggregator;

        #endregion

        #region Properties

        public ObservableCollection<NavigationItemViewModel> Friends
        {
            get { return _friends; }
            private set
            {
                _friends = value;
                OnPropertyChanged(nameof(Friends));
            }
        }

        #endregion

        #region Constructors

        public NavigationViewModel(INavigationDataProvider dataProvider, IEventAggregator eventAggregator)
        {
            _friends = new ObservableCollection<NavigationItemViewModel>();
            _dataProvider = dataProvider;
            _eventAggregator = eventAggregator;
        }

        #endregion

        public void LoadFriends()
        {
            Friends.Clear();
            foreach (var friend in _dataProvider.GetAllFriends())
            {
                Friends.Add(new NavigationItemViewModel(friend.Id,friend.DisplayMember, _eventAggregator));
            }
        }
    }
}