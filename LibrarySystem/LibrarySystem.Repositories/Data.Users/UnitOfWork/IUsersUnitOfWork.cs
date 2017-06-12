using LibrarySystem.Repositories.Contracts;
using LibrarySystem.Repositories.Data.Users.Contracts;

namespace LibrarySystem.Repositories.Data.Users.UnitOfWork
{
    public interface IUsersUnitOfWork : IUnitOfWork
    {
        IGroupRepository Groups { get; set; }

        IUserRepository Users { get; set; }
    }
}