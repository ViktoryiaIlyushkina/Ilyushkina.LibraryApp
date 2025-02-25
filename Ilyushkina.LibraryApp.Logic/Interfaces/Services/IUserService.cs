using Ilyushkina.LibraryApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ilyushkina.LibraryApp.Logic.Interfaces.Services
{
    public interface IUserService
    {
        public Task<string> ShowInfoAsync(User user);
    }
}
