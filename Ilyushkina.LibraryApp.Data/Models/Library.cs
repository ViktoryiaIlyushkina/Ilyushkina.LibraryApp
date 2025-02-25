using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ilyushkina.LibraryApp.Data.Models
{
    public class Library
    {
        public List<Book>? Books { get; set; }
        public List<User>? Users  { get; set; }
    }
}
