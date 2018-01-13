using System.Windows;
using FriendStorage.DataAccess;
using FriendStorage.UI.DataProviders;
using FriendStorage.UI.ViewModel;

namespace FriendStorage.UI.View
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _mainVieViewModel;

        public MainWindow()
        {
            InitializeComponent();

            _mainVieViewModel = new MainViewModel(
                new NavigationViewModel(
                    new NavigationDataProvider(() => new FileDataService())));

            DataContext = _mainVieViewModel;
            Loaded += HandleOnMainWindowLoaded;
        }

        private void HandleOnMainWindowLoaded(object sender, RoutedEventArgs e)
        {
            _mainVieViewModel.LoadFriends();
        }
    }
}