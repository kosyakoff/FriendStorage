namespace FriendStorage.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public NavigationViewModel NavigationViewModel { get; set; }

        public MainViewModel(NavigationViewModel navigationViewModel)
        {
            NavigationViewModel = navigationViewModel;
        }

        public void LoadFriends()
        {
            NavigationViewModel.LoadFriends();
        }
    }
}