using FriendStorage.UI.ViewModel;
using Xunit;

namespace UiTests.Viewmodel
{
    public class NavigationViewModelMock : INavigationViewModel
    {
        public bool LoadFriendsHasBeenCalled { get; set; }

        public void LoadFriends()
        {
            LoadFriendsHasBeenCalled = true;
        }
    }

    public class MainViewModelTests
    {
        [Fact]
        public void ShouldCallLoadMethodOfNavigationViewModel()
        {
            //Arrange
            var navigationViewModel = new NavigationViewModelMock();
            var viewModel = new MainViewModel(navigationViewModel);

            //Act
            viewModel.LoadFriends();

            //Assert
            Assert.True(navigationViewModel.LoadFriendsHasBeenCalled);
        }
    }
}