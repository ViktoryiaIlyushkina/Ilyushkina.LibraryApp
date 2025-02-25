using Ilyushkina.LibraryApp.Data.Models;
using Ilyushkina.LibraryApp.Logic.Comparers;
using Ilyushkina.LibraryApp.Logic.Interfaces.Services;

namespace Ilyushkina.LibraryApp.Logic.Services
{
    public class LibraryService : ILibraryService
    {
        public Task BorrowBookAsync(User user, Book book)
        {
            if (user.BooksQuantity == 3)
            {
                throw new ArgumentOutOfRangeException("Cannot borrow more than 3 books");
            }

            if (!book.IsAvailable || book.User != null)
            {
                throw new ArgumentException("The User is not registered or the Book is not available.");
            }


            user.BooksQuantity++;
            user.Books?.Add(book);
            book.IsAvailable = false;
            book.User = user;

            return Task.CompletedTask;
        }

        public Task ReturnBookAsync(User user, Book book)
        {
            if (!user.Books!.Contains(book))
            {
                throw new ArgumentException("Book cannot be returned because user doesn't have is");
            }

            if (book.IsAvailable || book.User == null)
            {
                throw new ArgumentException("Book cannot be returned because it is not in use now");
            }

            user.BooksQuantity--;
            user.Books!.Remove(book);
            book.IsAvailable = true;
            return Task.CompletedTask;
        }

        public Task AddBookAsync(Library library, Book book)
        {
            //var isEqual = false;
            //foreach (var b in library!.Books)
            //{
            //    if (b.ISBN == book.ISBN)
            //    {
            //        isEqual = true;
            //        break;
            //    }
            //}

            if (IsContains(library.Books!, book, new BookComparer()))
            {
                throw new ArgumentException("Book cannot be added to the library because library already contains this book");
            }

            library.Books!.Add(book);
            return Task.CompletedTask;
        }

        public Task RemoveBookAsync(Library library, Book book)
        {
            if (!IsContains(library.Books!, book, new BookComparer()))
            {
                throw new ArgumentException("Book cannot be removed from library because there is no such book in a library");
            }

            if (!book.IsAvailable || book.User != null)
            {
                throw new ArgumentException("Book cannot be removed from library because it is now in use");
            }

            library.Books!.Remove(book);
            return Task.CompletedTask;
        }

        public Task AddUserAsync(Library library, User user)
        {
            if (IsContains(library.Users!, user, new UserComparer()))
            {
                throw new ArgumentException("Cannot add user to library because this user already registered in the library");
            }

            library.Users!.Add(user);
            return Task.CompletedTask;
        }

        public Task RemoveUserAsync(Library library, User user)
        {
            //if (!library.Users!.Contains(user, new UserComparer()))
            //{
            //    return false;
            //}

            if (!IsContains(library.Users!, user, new UserComparer()))
            {
                throw new ArgumentException("Cannot remove user from library because user is not registered in library");
            }

            if (user.BooksQuantity != 0)
            {
                throw new ArgumentOutOfRangeException("Cannot remove user from library because user has books");
            }

            library.Users!.Remove(user);
            return Task.CompletedTask;
        }

        public Task<(bool, Book)> FindBookByTitleAsync(Library library, string title)
        {
            var book = library.Books!.FirstOrDefault(x => x.Title == title);

            if (book == null)
            {
                throw new ArgumentException();
            }

            return Task.FromResult((true, book));
        }

        private bool IsContains<T>(List<T> collection, T selectedObj, IEqualityComparer<T>? equalityComparer)
        {
            if (collection == null)
            {
                throw new ArgumentException();
            }

            return collection.Contains(selectedObj, equalityComparer);
        }
    }
}
