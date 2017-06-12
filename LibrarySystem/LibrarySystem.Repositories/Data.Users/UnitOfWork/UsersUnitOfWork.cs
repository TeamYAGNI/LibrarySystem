using Bytes2you.Validation;

using LibrarySystem.Data.Users;
using LibrarySystem.Repositories.Contracts;
using LibrarySystem.Repositories.Contracts.Data.Users;
using LibrarySystem.Repositories.Contracts.Data.Users.UnitOfWork;

namespace LibrarySystem.Repositories.Data.Users.UnitOfWork
{
    public class UsersUnitOfWork : IUnitOfWork, IUsersUnitOfWork
    {
        private readonly LibrarySystemUsersDbContext usersContext;

        public UsersUnitOfWork(LibrarySystemUsersDbContext usersContext, IUserRepository users, IGroupRepository groups)
        {
            Guard.WhenArgument(usersContext, "usersContext").IsNull().Throw();
            this.usersContext = usersContext;
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
