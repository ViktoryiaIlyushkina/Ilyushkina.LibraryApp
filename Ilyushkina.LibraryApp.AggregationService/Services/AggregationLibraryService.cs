using Ilyushkina.LibraryApp.AggregationService.Interfaces;
using Ilyushkina.LibraryApp.Data.Models;
using Ilyushkina.LibraryApp.Logic.Interfaces.Services;
using Ilyushkina.LibraryApp.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ilyushkina.LibraryApp.AggregationService.Services
{
    public class AggregationLibraryService : IAggregationLibraryService
    {
        private readonly ILibraryService _libraryService;
        private readonly Random _rand;
        public AggregationLibraryService(ILibraryService libraryService, Random rand)
        {
            _libraryService = libraryService;
            _rand = rand;
        }

        public async Task SimulateLibraryAsync(List<User> users, List<Book> books) 
        {
            try
            {
                await _libraryService.BorrowBookAsync(users[0], books[0]);
                await _libraryService.BorrowBookAsync(users[0], books[1]);
                await _libraryService.BorrowBookAsync(users[0], books[2]);
                await _libraryService.ReturnBookAsync(users[0], books[_rand.Next(0,2)]);
            }
            catch 
            {
                throw;
            }
           
        }
    }
}
