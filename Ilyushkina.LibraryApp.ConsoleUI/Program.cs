using Ilyushkina.LibraryApp.Data.Models;
using System.IO;
using System.Text.Json;
using System.Text;
using Ilyushkina.LibraryApp.Logic.Services;
using Ilyushkina.LibraryApp.AggregationService.Services;
using Ilyushkina.LibraryApp.AggregationService.Interfaces;

namespace Ilyushkina.LibraryApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            const string booksPath = "books.txt";
            const string usersPath = "users.txt";
            const string libraryPath = "library.txt";
            var bookService = new BookService();
            var userService = new UserService();
            var libraryService = new LibraryService();
            var fileService = new FileService();
            Random rand = new Random();
            IAggregationLibraryService aggregationLibraryService = new AggregationLibraryService(libraryService, rand);

            var books = await fileService.ReadFromJsonAsync<List<Book>>(booksPath);

            var users = await fileService.ReadFromJsonAsync<List<User>>(usersPath);

            var library = new Library();
            library.Books = books;
            library.Users = users;

            try
            {
                await aggregationLibraryService.SimulateLibraryAsync(users, books);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            foreach (var book in books)
            {
                Console.WriteLine(await bookService.ShowInfoAsync(book));
            }

            foreach (var user in users)
            {
                Console.WriteLine(await userService.ShowInfoAsync(user));
            }

            await fileService.WriteToJsonAsync(libraryPath, library);            
        }
    }
}
