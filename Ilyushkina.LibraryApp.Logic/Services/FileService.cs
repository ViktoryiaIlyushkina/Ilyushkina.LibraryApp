using Ilyushkina.LibraryApp.Data.Models;
using Ilyushkina.LibraryApp.Logic.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Ilyushkina.LibraryApp.Logic.Services
{
    public class FileService: IFileService
    {
        public async Task<T?> ReadFromJsonAsync<T>(string filePath)
        {
            using var sr = new StreamReader(filePath);
            var jsonText = await sr.ReadToEndAsync();

            if (string.IsNullOrEmpty(jsonText))
            {
                return default;
            }

            var jsonTextStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonText));

            var collection = await JsonSerializer.DeserializeAsync<T>(jsonTextStream);
            return collection;
        }

        public async Task WriteToJsonAsync<T>(string filePath, T data)
        {
            //await using var createStream = File.Create(filePath);
            //await JsonSerializer.SerializeAsync(createStream, data);

            using var sw = new StreamWriter(filePath, true);
            var jsonText = JsonSerializer.Serialize(data);

            if (!string.IsNullOrEmpty(jsonText))
            {
                await sw.WriteAsync(jsonText);
            }
        }
    }
}
