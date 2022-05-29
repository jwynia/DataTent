using System;
using System.IO;

namespace DataTent
{
    public class DataStore : IDataStore
    {
        private readonly string _baseFolderPath;

        public DataStore(string baseFolderPath)
        {
            _baseFolderPath = baseFolderPath ?? throw new ArgumentNullException(nameof(baseFolderPath));
            if (!Directory.Exists(_baseFolderPath))
            {
                Directory.CreateDirectory(_baseFolderPath);
            }
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public IDocumentCollection<T> GetCollection<T>() where T : class
        {
            var folder = Path.Combine(_baseFolderPath, typeof(T).Name);
            var collection = new DocumentCollection<T>(folder);
            return collection;
        }

        public void Reload()
        {
            throw new System.NotImplementedException();
        }
    }
}
