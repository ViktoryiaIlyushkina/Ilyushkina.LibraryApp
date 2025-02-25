using Ilyushkina.LibraryApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ilyushkina.LibraryApp.Data.Models
{
    public class EBook : Book
    {
        public EBookFormat Format { get; set; } 
    }
}
