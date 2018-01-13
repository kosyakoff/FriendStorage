using System.Collections.Generic;
using FriendStorage.Model;

namespace FriendStorage.UI.DataProviders
{
    public interface INavigationDataProvider
    {
        IEnumerable<LookupItem> GetAllFriends();
    }
}