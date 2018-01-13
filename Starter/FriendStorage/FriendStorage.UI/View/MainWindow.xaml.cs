using System.Windows;
using FriendStorage.UI.ViewModel;

namespace FriendStorage.UI.View
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _mainVieViewModel;

        public MainWindow()
        {
            InitializeComponent();

            _mainVieViewModel = new MainViewModel(new NavigationViewModel());
            DataContext = _mainVieViewModel;
            Loaded += HandleOnMainWindowLoaded;
        }

        private void HandleOnMainWindowLoaded(object sender, RoutedEventArgs e)
        {
            _mainVieViewModel.LoadFriends();
        }
    }
}