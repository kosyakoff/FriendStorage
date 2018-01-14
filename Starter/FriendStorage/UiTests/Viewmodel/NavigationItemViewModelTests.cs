﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendStorage.UI.Events;
using FriendStorage.UI.ViewModel;
using Moq;
using Prism.Events;
using Xunit;

namespace UiTests.Viewmodel
{
    public class NavigationItemViewModelTests
    {
        [Fact]
        public void ShouldPublishOpenFriendViewEvent()
        {
            //Arrange
            const int frientId = 7;

            var eventMock = new Mock<OpenFriendEditViewEvent>();
            var eventAggregatorMock = new Mock<IEventAggregator>();
            eventAggregatorMock.Setup(ea => ea.GetEvent<OpenFriendEditViewEvent>())
                .Returns(eventMock.Object);

            var navigationItemViewModel = new NavigationItemViewModel(frientId, "Jonathan", eventAggregatorMock.Object);

            //Act
            navigationItemViewModel.OpenFriendEditViewCommand.Execute(null);

            //Assert
            eventMock.Verify(e => e.Publish(frientId),Times.Once);
        }
    }
}
