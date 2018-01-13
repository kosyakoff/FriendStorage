using System;
using System.Collections.Generic;
using FriendStorage.DataAccess;
using FriendStorage.Model;

namespace FriendStorage.UI.DataProviders
{
    public class NavigationDataProvider : INavigationDataProvider
    {
        private readonly Func<IDataService> _dataServiceCreator;

        public NavigationDataProvider(Func<IDataService> dataServiceCreatorCreator)
        {
            _dataServiceCreator = dataServiceCreatorCreator;
        }

        public IEnumerable<LookupItem> GetAllFriends()
        {
            using (var dataService = _dataServiceCreator())
            {
                return dataService.GetAllFriends();
            }
        }
    }
}