using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ilyushkina.LibraryApp.Logic.Interfaces.Services
{
    public interface IFileService
    {
        public Task<T?> ReadFromJsonAsync<T>(string filePath);
        public Task WriteToJsonAsync<T>(string filePath, T data);
    }
}
