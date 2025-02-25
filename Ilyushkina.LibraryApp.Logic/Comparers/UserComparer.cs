using Ilyushkina.LibraryApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ilyushkina.LibraryApp.Logic.Comparers
{
    public class UserComparer : IEqualityComparer<User>
    {
        public bool Equals(User? x, User? y)
        {
            if (x == null && y == null)
            {
                new ArgumentException("Некорректное значение параметра");
            }
            return x!.Id == y!.Id;
        }

        public int GetHashCode([DisallowNull] User obj)
        {
           return obj.Id.GetHashCode();
        }
    }
}
