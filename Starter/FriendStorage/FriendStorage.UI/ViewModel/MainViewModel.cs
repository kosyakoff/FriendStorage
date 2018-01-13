namespace FriendStorage.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public INavigationViewModel NavigationViewModel { get; set; }

        public MainViewModel(INavigationViewModel navigationViewModel)
        {
            NavigationViewModel = navigationViewModel;
        }

        public void LoadFriends()
        {
            NavigationViewModel.LoadFriends();
        }
    }
}