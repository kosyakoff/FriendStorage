using System.Windows;
using FriendStorage.UI.ViewModel;

namespace FriendStorage.UI.View
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _mainVieViewModel;

        public MainWindow(MainViewModel mainViewModel)
        {
            InitializeComponent();

            _mainVieViewModel = mainViewModel;

            DataContext = _mainVieViewModel;
            Loaded += HandleOnMainWindowLoaded;
        }

        private void HandleOnMainWindowLoaded(object sender, RoutedEventArgs e)
        {
            _mainVieViewModel.LoadFriends();
        }
    }
}