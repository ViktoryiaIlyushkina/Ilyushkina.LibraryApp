using Ilyushkina.LibraryApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ilyushkina.LibraryApp.AggregationService.Interfaces
{
    public interface IAggregationLibraryService
    {
        public Task SimulateLibraryAsync(List<User> users, List<Book> books);
    }
}
