using Ilyushkina.LibraryApp.Data.Models;
using Ilyushkina.LibraryApp.Logic.Interfaces.Services;

namespace Ilyushkina.LibraryApp.Logic.Services
{
    public class UserService : IUserService
    {
        public Task<string> ShowInfoAsync(User user)
        {
            var result = $"ID: {user.Id}\nName: {user.Name}\nContact Info: {user.ContactInfo}\nBooks: {user.BooksQuantity}\n";
            return Task.FromResult(result);
        }
    }
}
