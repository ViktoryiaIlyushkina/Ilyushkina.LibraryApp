using Ilyushkina.LibraryApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ilyushkina.LibraryApp.Logic.Comparers
{
    public class BookComparer : IEqualityComparer<Book>
    {
        //public int Compare(Book? x, Book? y)
        //{
        //    if (x == null && y == null)
        //    {
        //        new ArgumentException("Некорректное значение параметра");
        //    }
        //    return x!.ISBN - y!.ISBN;
        //}

        public bool Equals(Book? x, Book? y)
        {

            if (x == null && y == null)
            {
                new ArgumentException("Некорректное значение параметра");
            }
            return x!.ISBN == y!.ISBN;
        }

        public int GetHashCode([DisallowNull] Book obj)
        {
           return obj.ISBN.GetHashCode();
        }
    }
}
