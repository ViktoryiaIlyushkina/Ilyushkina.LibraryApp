using Ilyushkina.LibraryApp.Data.Models;
using Ilyushkina.LibraryApp.Logic.Interfaces.Services;
using Ilyushkina.LibraryApp.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ilyushkina.LibraryApp.UnitTest.Services
{
    public class BookServiceTests
    {
        [Fact]
        public void ShowInfo_CorrectData_Returns_GeneratedString()
        {
            // Arrange
            var book = new Book
            {
                Id = 1,
                Author = nameof(Book.Author),
                IsAvailable = true,
                ISBN = 1,
                Title = nameof(Book.Title)
            };

            string expectedString = "ID: 1\nTitle: Title\nAuthor: Author\nISBN: 1\nIsAvailable: True\n";

            // Act
            IBookService bookService = new BookService();
            var result = bookService.ShowInfoAsync(book).GetAwaiter().GetResult();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expectedString, result);
        }

        [Fact]
        public void ShowInfo_NullBook_Throws_NullReferenceException()
        {
            // Arrange
            Book book = null;

            // Act
            IBookService bookService = new BookService();

            // Assert
            Assert.Throws<NullReferenceException>(() => bookService.ShowInfoAsync(book).GetAwaiter().GetResult());
        }
    }
}
