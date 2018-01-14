using System.Collections.Generic;
using System.Linq;
using FriendStorage.Model;
using FriendStorage.UI.DataProviders;
using FriendStorage.UI.ViewModel;
using Moq;
using Prism.Events;
using Xunit;

namespace UiTests.Viewmodel
{
    public class NavigationViewmodelTests
    {
        public NavigationViewmodelTests()
        {
            var navigationDataProviderMock = new Mock<INavigationDataProvider>();
            navigationDataProviderMock.Setup(provider => provider.GetAllFriends()).Returns(
                new List<LookupItem>
                {
                    new LookupItem {Id = 1, DisplayMember = "Julia"},
                    new LookupItem {Id = 2, DisplayMember = "Fedor"}
                }
            );
            var eventAggregatorMock = new Mock<IEventAggregator>();

            _navigationViewModel = new NavigationViewModel(navigationDataProviderMock.Object, eventAggregatorMock.Object);
        }

        private readonly NavigationViewModel _navigationViewModel;

        [Fact]
        public void ShouldLoadFriends()
        {
            //Act
            _navigationViewModel.LoadFriends();

            var firstFriend = _navigationViewModel.Friends.FirstOrDefault(friend => friend.Id == 1);
            var secondFriend = _navigationViewModel.Friends.FirstOrDefault(friend => friend.Id == 2);

            //Assert
            Assert.Equal(2, _navigationViewModel.Friends.Count);

            Assert.NotNull(firstFriend);
            Assert.Equal("Julia", firstFriend.DisplayMember);

            Assert.NotNull(secondFriend);
            Assert.Equal("Fedor", secondFriend.DisplayMember);
        }

        [Fact]
        public void ShouldLoadFriendsOnlyOnce()
        {
            //Arrange

            //Act
            _navigationViewModel.LoadFriends();
            _navigationViewModel.LoadFriends();

            //Assert
            Assert.Equal(2, _navigationViewModel.Friends.Count);
        }
    }
}