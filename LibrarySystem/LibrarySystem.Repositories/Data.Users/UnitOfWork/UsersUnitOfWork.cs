using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Repositories.Contracts;

namespace LibrarySystem.Repositories.Data.Users.UnitOfWork
{
    public class UsersUnitOfWork : IUnitOfWork
    {
        public UsersUnitOfWork()
        {
            
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int Commit()
        {
            throw new NotImplementedException();
        }
    }
}
