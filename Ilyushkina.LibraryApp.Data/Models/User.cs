using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ilyushkina.LibraryApp.Data.Models
{
    public class User
    {
        private string _name = string.Empty;
        public int Id { get; set; }
        public string? Name 
        {
            get { return _name; }
            set { _name = value; }
        }
        public string? ContactInfo { get; set; }
        public int BooksQuantity { get; set; }

        public List<Book>? Books { get; set; } = new List<Book>();
    }
}
