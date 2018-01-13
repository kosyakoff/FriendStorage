using System.Collections.Generic;
using System.Linq;
using FriendStorage.Model;
using FriendStorage.UI.DataProviders;
using FriendStorage.UI.ViewModel;
using Xunit;

namespace UiTests.Viewmodel
{
    public class NavigationDataProviderMock : INavigationDataProvider
    {
        public IEnumerable<LookupItem> GetAllFriends()
        {
            yield return new LookupItem {Id = 1, DisplayMember = "Julia"};
            yield return new LookupItem {Id = 2, DisplayMember = "Fedor"};
        }
    }

    public class NavigationViewmodelTests
    {
        [Fact]
        public void ShouldLoadFriends()
        {
            //Arrange
            var navigationViewModel = new NavigationViewModel(new NavigationDataProviderMock());

            //Act
            navigationViewModel.LoadFriends();

            var firstFriend = navigationViewModel.Friends.FirstOrDefault(friend => friend.Id == 1);
            var secondFriend = navigationViewModel.Friends.FirstOrDefault(friend => friend.Id == 2);

            //Assert
            Assert.Equal(2, navigationViewModel.Friends.Count);

            Assert.NotNull(firstFriend);
            Assert.Equal("Julia", firstFriend.DisplayMember);

            Assert.NotNull(secondFriend);
            Assert.Equal("Fedor", secondFriend.DisplayMember);
        }

        [Fact]
        public void ShouldLoadFriendsOnlyOnce()
        {
            //Arrange
            var navigationViewModel = new NavigationViewModel(new NavigationDataProviderMock());

            //Act
            navigationViewModel.LoadFriends();
            navigationViewModel.LoadFriends();

            //Assert
            Assert.Equal(2, navigationViewModel.Friends.Count);
        }
    }
}