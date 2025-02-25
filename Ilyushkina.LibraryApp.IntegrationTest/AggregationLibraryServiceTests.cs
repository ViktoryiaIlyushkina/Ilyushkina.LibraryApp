using Ilyushkina.LibraryApp.AggregationService.Interfaces;
using Ilyushkina.LibraryApp.AggregationService.Services;
using Ilyushkina.LibraryApp.Data.Models;
using Ilyushkina.LibraryApp.Logic.Interfaces.Services;
using Ilyushkina.LibraryApp.Logic.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ilyushkina.LibraryApp.IntegrationTest
{
   public class AggregationLibraryServiceTests
    {
        [Fact]
        public void SimulateLibrary_CorrectData_AddsAndRemoves_Books()
        {
            // Arrange
            var user = new User()
            {
                Id = 1,
                Name = nameof(User.Name),
                ContactInfo = nameof(User.ContactInfo),
                BooksQuantity = 0
            };
            var book1 = new Book()
            {
                Id = 1,
                Author = nameof(Book.Author),
                IsAvailable = true,
                ISBN = 1,
                Title = nameof(Book.Title)
            };
            var book2 = new Book()
            {
                Id = 2,
                Author = nameof(Book.Author),
                IsAvailable = true,
                ISBN = 2,
                Title = nameof(Book.Title)
            };
            var book3= new Book()
            {
                Id = 3,
                Author = $"{nameof(Book.Author)}3",
                IsAvailable = true,
                ISBN = 3,
                Title = $"{nameof(Book.Title)}3"
            };
            var users = new List<User> { user };
            var books = new List<Book> { book1, book2, book3 };
            var mock = new Mock<Random>();
            mock.Setup(rnd => rnd.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(0);
            //mock.Setup(rnd => rnd.Next(0, 2)).Returns(0);

            // Act
            ILibraryService libraryService = new LibraryService();
            Random rand = new Random();
            IAggregationLibraryService aggregationLibraryService = new AggregationLibraryService(libraryService, rand);
            aggregationLibraryService.SimulateLibraryAsync(users, books).GetAwaiter().GetResult();

            // Assert
            Assert.NotEmpty(users[0].Books);
            Assert.Equal(2, users[0].BooksQuantity);
            //Assert.Equal(book2.Id, users[0].Books[0].Id);
            //Assert.Equal(book3.Id, users[0].Books[1].Id);
        }
    }
}
