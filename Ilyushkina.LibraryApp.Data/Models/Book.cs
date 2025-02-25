using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ilyushkina.LibraryApp.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int ISBN { get; set; }
        public bool IsAvailable { get; set; }

        public User? User { get; set; }
    }
}
