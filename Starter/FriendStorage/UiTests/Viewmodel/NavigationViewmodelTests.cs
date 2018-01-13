using FriendStorage.UI.ViewModel;
using Xunit;

namespace UiTests.Viewmodel
{

    public class NavigationViewmodelTests
    {
        [Fact]
        public void ShouldLoadFriends()
        {
            //Arrange
            var navigationViewModel = new NavigationViewModel();

            //Act
            navigationViewModel.LoadFriends();

            //Assert
            Assert.Equal(8,navigationViewModel.Friends.Count); 
        }
    }
}
