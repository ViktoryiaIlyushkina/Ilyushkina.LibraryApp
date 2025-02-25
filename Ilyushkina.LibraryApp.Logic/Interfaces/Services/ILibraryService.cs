using Ilyushkina.LibraryApp.Data.Models;
using Ilyushkina.LibraryApp.Logic.Comparers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ilyushkina.LibraryApp.Logic.Interfaces.Services
{
    public interface ILibraryService
    {
        public Task BorrowBookAsync(User user, Book book);

        public Task ReturnBookAsync(User user, Book book);

        public Task AddBookAsync(Library library, Book book);

        public Task RemoveBookAsync(Library library, Book book);

        public Task AddUserAsync(Library library, User user);

        public Task RemoveUserAsync(Library library, User user);

        public Task<(bool, Book)> FindBookByTitleAsync(Library library, string title);
    }
}
