using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Commands.Contracts;

namespace LibrarySystem.ConsoleClient.Interceptors
{
    public class UserPassport : IUserPassport
    {
        public string Username { get; set; }

        public string AuthKey { get; set; }
    }
}
