using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Data.Users;
using LibrarySystem.Models.Enumerations;
using LibrarySystem.Models.Users;
using LibrarySystem.Repositories.Abstractions;
using LibrarySystem.Repositories.Contracts;
using LibrarySystem.Repositories.Data.Users.Contracts;

namespace LibrarySystem.Repositories.Data.Users
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(DbContext context) : base(context)
        {
        }

        private LibrarySystemUsersDbContext UsersDbContext
        {
            get
            {
                return this.Context as LibrarySystemUsersDbContext;
            }
        }

        public IEnumerable<Group> GetGroupsByUser(string username)
        {
            return this.UsersDbContext.Groups.Where(g => g.Users.Any(u => u.Username == username)).ToList();
        }

        public IEnumerable<Group> GetGroupsWithMasters()
        {
            return this.UsersDbContext.Groups.Where(g => g.Users.Any(u => u.Type == UserType.Master)).ToList();
        }

        public Group GetGroupByName(string groupName)
        {
            return this.UsersDbContext.Groups.FirstOrDefault(g => g.Name == groupName);
        }
    }
}
