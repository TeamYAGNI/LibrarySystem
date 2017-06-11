using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytes2you.Validation;
using LibrarySystem.Data.Users;
using LibrarySystem.Repositories.Contracts;
using LibrarySystem.Repositories.Data.Users.Contracts;

namespace LibrarySystem.Repositories.Data.Users.UnitOfWork
{
    public class UsersUnitOfWork : IUnitOfWork, IUsersUnitOfWork
    {
        private readonly LibrarySystemUsersDbContext usersContext;

        private IUserRepository users;
        private IGroupRepository groups;

        public UsersUnitOfWork(LibrarySystemUsersDbContext usersContext, IUserRepository users, IGroupRepository groups)
        {
            Guard.WhenArgument(usersContext, "usersContext").IsNull().Throw();
            this.usersContext = usersContext;

            this.Users = users;
            this.Groups = groups;
        }

        public IUserRepository Users
        {
            get
            {
                return this.users;
            }

            set
            {
                Guard.WhenArgument(value, "Users").IsNull().Throw();

                this.users = value;
            }
        }

        public IGroupRepository Groups
        {
            get
            {
                return this.groups;
            }

            set
            {
                Guard.WhenArgument(value, "Groups").IsNull().Throw();

                this.groups = value;
            }
        }

        public void Dispose()
        {
            this.usersContext.Dispose();
        }

        public int Commit()
        {
            return this.usersContext.SaveChanges();
        }
    }
}
