using Ilyushkina.LibraryApp.Data.Models;
using Ilyushkina.LibraryApp.Logic.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ilyushkina.LibraryApp.Logic.Services
{
    public class BookService : IBookService
    {
        public Task<string> ShowInfoAsync(Book book)
        {
            if (book is null)
            {
                throw new NullReferenceException();
            }
            var result = $"ID: {book.Id}\nTitle: {book.Title}\nAuthor: {book.Author}\nISBN: {book.ISBN}\nIsAvailable: {book.IsAvailable}\n";
            return Task.FromResult(result);
        }
    }
}
