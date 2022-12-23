using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Text.Json;

namespace DataTent
{
    public class DocumentCollection<T> : IDocumentCollection<T>
    {
        private readonly string _folder;
        private IList<T> _collection = new List<T>();
        private JsonSerializerOptions jsonSerializerOptions;

        public DocumentCollection(string folder)
        {
            jsonSerializerOptions = new JsonSerializerOptions(){WriteIndented = true};
            _folder = folder ?? throw new ArgumentNullException(nameof(folder));
            if (!Directory.Exists(_folder))
            {
                Directory.CreateDirectory(_folder);
            }
            Load();
        }
        
        public IQueryable<T> AsQueryable()
        {
            return _collection.AsQueryable();
        }

        public IEnumerable<T> Find(Predicate<T> query)
        {
            return _collection.Where(t => query(t));
        }

        public bool InsertOne(T item, string uniqueId)
        {
            var fileName = Path.Combine(_folder, $"{uniqueId}.json");
            if (File.Exists(fileName))
            {
                throw new ArgumentException($"Record already exists with uniqueId: {uniqueId}");
            }
            _collection.Add(item);
            var serialized = JsonSerializer.Serialize(item, jsonSerializerOptions);
            File.WriteAllText(fileName, serialized);
            return true;
        }

        public bool ReplaceOne(T item, string uniqueId)
        {
            _collection.Add(item);
            
            var serialized = JsonSerializer.Serialize(item, jsonSerializerOptions);
            var fileName = Path.Combine(_folder, $"{uniqueId}.json");
            File.WriteAllText(fileName, serialized);
            return true;
        }

        public bool DeleteOne(string uniqueId)
        {
            var fileName = Path.Combine(_folder, $"{uniqueId}.json");
            var serialized = File.ReadAllText(fileName);
            var toDelete = JsonSerializer.Deserialize<T>(serialized);
            _collection.Remove(toDelete);
            File.Delete(fileName);
            return true;
        }

        public int Count => _collection.Count;

        public void Reload()
        {
            _collection = new List<T>();
            Load();
        }

        private void Load()
        {
            var files = Directory.GetFiles(_folder);
            foreach (var file in files.Where(f=>f.EndsWith(".json")))
            {
                var serialized = File.ReadAllText(file);
                var deserialized = JsonSerializer.Deserialize<T>(serialized);
                _collection.Add(deserialized);
            }
        }
    }
}