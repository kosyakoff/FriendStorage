using FriendStorage.UI.ViewModel;
using Moq;
using Xunit;

namespace UiTests.Viewmodel
{
    public class MainViewModelTests
    {
        public MainViewModelTests()
        {
            _navigationViewModelMock = new Mock<INavigationViewModel>();
        }

        private readonly Mock<INavigationViewModel> _navigationViewModelMock;

        [Fact]
        public void ShouldCallLoadMethodOfNavigationViewModel()
        {
            //Arrange
            var mainViewModel = new MainViewModel(_navigationViewModelMock.Object);

            //Act
            mainViewModel.LoadFriends();

            //Assert
            _navigationViewModelMock.Verify(model => model.LoadFriends(),
                Times.Once);
        }
    }
}