using Ilyushkina.LibraryApp.Data.Models;
using Ilyushkina.LibraryApp.Logic.Interfaces.Services;
using Ilyushkina.LibraryApp.Logic.Services;

namespace Ilyushkina.LibraryApp.UnitTest.Services
{
    public class LibraryServiceTests
    {
        [Fact]
        public void BorrowBook_CorrectData_Adds_BookToUser()
        {
            // Arrange
            var user = new User()
            {
                Id = 1,
                Name = nameof(User.Name),
                ContactInfo = nameof(User.ContactInfo),
                BooksQuantity = 0
            };
            var book = new Book()
            {
                Id = 1,
                Author = nameof(Book.Author),
                IsAvailable = true,
                ISBN = 1,
                Title = nameof(Book.Title)
            };

            // Act
            ILibraryService libraryService = new LibraryService();
            libraryService.BorrowBookAsync(user, book).GetAwaiter().GetResult();


            // Assert
            Assert.NotNull(user);
            Assert.NotNull(user.Books);
            Assert.NotNull(book.User);
            Assert.NotNull(book);
            Assert.True(user.BooksQuantity == 1);
            Assert.Contains(book, user.Books);
        }

        [Fact]
        public void BorrowBook_BooksQuantityExceedsLimit_Throws_ArgumentOutOfRangeException()
        {
            // Arrange
            var user = new User()
            {
                Id = 1,
                Name = nameof(User.Name),
                ContactInfo = nameof(User.ContactInfo),
                BooksQuantity = 3
            };
            var book = new Book()
            {
                Id = 1,
                Author = nameof(Book.Author),
                IsAvailable = true,
                ISBN = 1,
                Title = nameof(Book.Title)
            };


            // Act
            ILibraryService libraryService = new LibraryService();


            // Assert
            Assert.NotNull(user);
            Assert.NotNull(user.Books);
            Assert.NotNull(book);
            Assert.Throws<ArgumentOutOfRangeException>(() => libraryService.BorrowBookAsync(user, book).GetAwaiter().GetResult());
        }

        [Fact]
        public void BorrowBook_NotAvaliableBook_Throws_ArgumentException()
        {
            // Arrange
            var user = new User()
            {
                Id = 1,
                Name = nameof(User.Name),
                ContactInfo = nameof(User.ContactInfo),
                BooksQuantity = 1
            };
            var book = new Book()
            {
                Id = 1,
                Author = nameof(Book.Author),
                IsAvailable = false,
                ISBN = 1,
                Title = nameof(Book.Title)
            };

            // Act
            ILibraryService libraryService = new LibraryService();

            // Assert
            Assert.NotNull(user);
            Assert.NotNull(book);
            Assert.Throws<ArgumentException>(() => libraryService.BorrowBookAsync(user, book).GetAwaiter().GetResult());
        }

        [Fact]
        public void ReturnBook_CorrectData_Removes_BookFromUser()
        {
            // Arrange
            var book = new Book()
            {
                Id = 1,
                Author = nameof(Book.Author),
                IsAvailable = false,
                ISBN = 1,
                Title = nameof(Book.Title)
            };
            var user = new User()
            {
                Id = 1,
                Name = nameof(User.Name),
                ContactInfo = nameof(User.ContactInfo),
                BooksQuantity = 1,
                Books = new List<Book>() { book }
            };
            book.User = user;

            // Act
            ILibraryService libraryService = new LibraryService();
            libraryService.ReturnBookAsync(user, book).GetAwaiter().GetResult();

            // Assert
            Assert.NotNull(user);
            Assert.NotNull(book);
            Assert.True(user.BooksQuantity == 0);
            Assert.DoesNotContain(book, user.Books);
        }

        [Fact]
        public void ReturnBook_UserDoesNotHaveBook_Throws_ArgumentException()
        {
            // Arrange
            var user = new User()
            {
                Id = 1,
                Name = nameof(User.Name),
                ContactInfo = nameof(User.ContactInfo),
                BooksQuantity = 0
            };
            var book = new Book()
            {
                Id = 1,
                Author = nameof(Book.Author),
                IsAvailable = true,
                ISBN = 1,
                Title = nameof(Book.Title)
            };

            // Act
            ILibraryService libraryService = new LibraryService();

            // Assert
            Assert.NotNull(user);
            Assert.NotNull(user.Books);
            Assert.NotNull(book);
            Assert.Throws<ArgumentException>(() => libraryService.ReturnBookAsync(user, book).GetAwaiter().GetResult());
        }

        [Fact]
        public void ReturnBook_NotAvaliableBook_Throws_ArgumentException()
        {
            // Arrange
            var user = new User()
            {
                Id = 1,
                Name = nameof(User.Name),
                ContactInfo = nameof(User.ContactInfo),
                BooksQuantity = 1
            };
            var book = new Book()
            {
                Id = 1,
                Author = nameof(Book.Author),
                IsAvailable = true,
                ISBN = 1,
                Title = nameof(Book.Title)
            };

            // Act
            ILibraryService libraryService = new LibraryService();

            // Assert
            Assert.NotNull(user);
            Assert.NotNull(book);
            Assert.Throws<ArgumentException>(() => libraryService.ReturnBookAsync(user, book).GetAwaiter().GetResult());
        }

        [Fact]
        public void AddBook_CorrectData_Adds_BookToLibrary()
        {
            // Arrange
            var library = new Library()
            {
                Users = new List<User>(),
                Books = new List<Book>()
            };
            var book = new Book()
            {
                Id = 1,
                Author = nameof(Book.Author),
                IsAvailable = true,
                ISBN = 1,
                Title = nameof(Book.Title)
            };

            // Act
            ILibraryService libraryService = new LibraryService();
            libraryService.AddBookAsync(library, book);

            // Assert
            Assert.NotNull(library);
            Assert.NotNull(book);
            Assert.Contains(book, library.Books);
        }

        [Fact]
        public void AddBook_LibraryHasBook_Throws_ArgumentException()
        {
            // Arrange
            var book = new Book()
            {
                Id = 1,
                Author = nameof(Book.Author),
                IsAvailable = true,
                ISBN = 1,
                Title = nameof(Book.Title)
            };
            var library = new Library()
            {
                Users = new List<User>(),
                Books = new List<Book>() { book }
            };
           

            // Act
            ILibraryService libraryService = new LibraryService();
            

            // Assert
            Assert.NotNull(library);
            Assert.NotNull(book);
            Assert.Throws<ArgumentException> (() => libraryService.AddBookAsync(library, book).GetAwaiter().GetResult());
        }

        [Fact]
        public void RemoveBook_CorrectData_Removes_BookFromLibrary()
        {
            // Arrange
            var book = new Book()
            {
                Id = 1,
                Author = nameof(Book.Author),
                IsAvailable = true,
                ISBN = 1,
                Title = nameof(Book.Title)
            };
            var library = new Library()
            {
                Users = new List<User>(),
                Books = new List<Book>() { book }
            };
           
            // Act
            ILibraryService libraryService = new LibraryService();
            libraryService.RemoveBookAsync(library, book);

            // Assert
            Assert.NotNull(library);
            Assert.NotNull(book);
            Assert.DoesNotContain(book, library.Books);
        }

        [Fact]
        public void RemoveBook_BookIsNotContainedInLibrary_Throws_ArgumentException()
        {
            // Arrange
            var book = new Book()
            {
                Id = 1,
                Author = nameof(Book.Author),
                IsAvailable = true,
                ISBN = 1,
                Title = nameof(Book.Title)
            };
            var library = new Library()
            {
                Users = new List<User>(),
                Books = new List<Book>()
            };

            // Act
            ILibraryService libraryService = new LibraryService();

            // Assert
            Assert.NotNull(library);
            Assert.NotNull(book);
            Assert.Throws<ArgumentException> (() => libraryService.RemoveBookAsync(library, book).GetAwaiter().GetResult());
        }

        [Fact]
        public void RemoveBook_BookTakenByUserNotAvaliable_Throws_ArgumentException()
        {
            // Arrange
            var book = new Book()
            {
                Id = 1,
                Author = nameof(Book.Author),
                IsAvailable = false,
                ISBN = 1,
                Title = nameof(Book.Title)
            };
            var library = new Library()
            {
                Users = new List<User>(),
                Books = new List<Book>() { book }
            };
            var user = new User()
            {
                Id = 1,
                Name = nameof(User.Name),
                ContactInfo = nameof(User.ContactInfo),
                BooksQuantity = 1,
                Books = new List<Book> { book }
            };
            book.User = user;

            // Act
            ILibraryService libraryService = new LibraryService();

            // Assert
            Assert.NotNull(library);
            Assert.NotNull(book);
            Assert.Throws<ArgumentException>(() => libraryService.RemoveBookAsync(library, book).GetAwaiter().GetResult());
        }

        [Fact]
        public void AddUser_CorrectData_Adds_UserToLibrary()
        {
            // Arrange
            var user = new User()
            {
                Id = 1,
                Name = nameof(User.Name),
                ContactInfo = nameof(User.ContactInfo),
                BooksQuantity = 0,
                Books = new List<Book>()
            };
            var library = new Library()
            {
                Users = new List<User>(),
                Books = new List<Book>()
            };

            // Act
            ILibraryService libraryService = new LibraryService();
            libraryService.AddUserAsync(library, user);

            // Assert
            Assert.NotNull(library);
            Assert.NotNull(user);
            Assert.Contains(user, library.Users);
        }

        [Fact]
        public void AddUser_LibraryHasUser_Throws_ArgumentException()
        {
            // Arrange
            var user = new User()
            {
                Id = 1,
                Name = nameof(User.Name),
                ContactInfo = nameof(User.ContactInfo),
                BooksQuantity = 0,
                Books = new List<Book>()
            };
            var library = new Library()
            {
                Users = new List<User>() { user },
                Books = new List<Book>()
            };

            // Act
            ILibraryService libraryService = new LibraryService();

            // Assert
            Assert.NotNull(library);
            Assert.NotNull(user);
            Assert.Throws<ArgumentException>(() => libraryService.AddUserAsync(library, user).GetAwaiter().GetResult());
        }

        [Fact]
        public void RemoveUser_CorrectData_Removes_UserFromLibrary()
        {
            // Arrange
            var user = new User()
            {
                Id = 1,
                Name = nameof(User.Name),
                ContactInfo = nameof(User.ContactInfo),
                BooksQuantity = 0,
                Books = new List<Book>()
            };
            var library = new Library()
            {
                Users = new List<User>() { user },
                Books = new List<Book>() 
            };

            // Act
            ILibraryService libraryService = new LibraryService();
            libraryService.RemoveUserAsync(library, user);

            // Assert
            Assert.NotNull(library);
            Assert.NotNull(user);
            Assert.DoesNotContain(user, library.Users);
        }

        [Fact]
        public void RemoveUser_UserIsNotContainedInLibrary_Throws_ArgumentException()
        {
            // Arrange
            var user = new User()
            {
                Id = 1,
                Name = nameof(User.Name),
                ContactInfo = nameof(User.ContactInfo),
                BooksQuantity = 0,
                Books = new List<Book>()
            };
            var library = new Library()
            {
                Users = new List<User>(),
                Books = new List<Book>()
            };

            // Act
            ILibraryService libraryService = new LibraryService();

            // Assert
            Assert.NotNull(library);
            Assert.NotNull(user);
            Assert.Throws<ArgumentException>(() => libraryService.RemoveUserAsync(library, user).GetAwaiter().GetResult());
        }

        [Fact]
        public void RemoveUser_UserHasBooks_Throws_ArgumentOutOfRangeException()
        {
            // Arrange
            var book = new Book()
            {
                Id = 1,
                Author = nameof(Book.Author),
                IsAvailable = false,
                ISBN = 1,
                Title = nameof(Book.Title)
            };
            var user = new User()
            {
                Id = 1,
                Name = nameof(User.Name),
                ContactInfo = nameof(User.ContactInfo),
                BooksQuantity = 1,
                Books = new List<Book> { book }
            };
            var library = new Library()
            {
                Users = new List<User>() { user },
                Books = new List<Book>() { book }
            };
            book.User = user;

            // Act
            ILibraryService libraryService = new LibraryService();

            // Assert
            Assert.NotNull(library);
            Assert.NotNull(book);
            Assert.Throws<ArgumentOutOfRangeException>(() => libraryService.RemoveUserAsync(library, user).GetAwaiter().GetResult());
        }

        [Fact]
        public void FindBookByTitle_CorrectData_Returns_TupleTrueBook()
        {
            // Arrange
            var book = new Book()
            {
                Id = 1,
                Author = nameof(Book.Author),
                IsAvailable = false,
                ISBN = 1,
                Title = nameof(Book.Title)
            };
            var user = new User()
            {
                Id = 1,
                Name = nameof(User.Name),
                ContactInfo = nameof(User.ContactInfo),
                BooksQuantity = 1,
                Books = new List<Book> { book }
            };
            var library = new Library()
            {
                Users = new List<User>() { user },
                Books = new List<Book>() { book }
            };
            book.User = user;
            var expectedResult = (true, book);

            // Act
            ILibraryService libraryService = new LibraryService();
            var result = libraryService.FindBookByTitleAsync(library,book.Title).GetAwaiter().GetResult();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult, result);
        }
    }
}
