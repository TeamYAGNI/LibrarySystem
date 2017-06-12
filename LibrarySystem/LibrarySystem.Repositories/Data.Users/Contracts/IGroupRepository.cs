using System.Collections.Generic;
using LibrarySystem.Models.Users;
using LibrarySystem.Repositories.Contracts;

namespace LibrarySystem.Repositories.Data.Users.Contracts
{
    public interface IGroupRepository : IRepository<Group>
    {
        Group GetGroupByName(string groupName);

        IEnumerable<Group> GetGroupsByUser(string username);

        IEnumerable<Group> GetGroupsWithMasters();
    }
}