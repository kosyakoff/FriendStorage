using System;
using System.Windows.Input;
using FriendStorage.UI.Command;
using FriendStorage.UI.Events;
using Prism.Events;

namespace FriendStorage.UI.ViewModel
{
    public class NavigationItemViewModel : ViewModelBase
    {
        private IEventAggregator _eventAggregator;

        #region Properties

        public int Id { get; set; }
        public string DisplayMember { get; set; }
        public ICommand OpenFriendEditViewCommand { get; set; }

        #endregion

        #region Constructors

        public NavigationItemViewModel(int id, string displayMember,IEventAggregator eventAggregator)
        {
            Id = id;
            DisplayMember = displayMember;
            OpenFriendEditViewCommand = new DelegateCommand(OpenFriendEditViewExecute);

            _eventAggregator = eventAggregator;
        }

        #endregion

        private void OpenFriendEditViewExecute(object obj)
        {
            _eventAggregator.GetEvent<OpenFriendEditViewEvent>().Publish(Id);
        }
    }
}