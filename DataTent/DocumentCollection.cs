using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace DataTent
{
	public class DocumentCollection<T>: IDocumentCollection<T>
	{
		private readonly string _folder;
		private IList<T> _collection = new List<T>();
		public DocumentCollection(string folder)
		{
			_folder = folder ?? throw new ArgumentNullException(nameof(folder));
			var files = Directory.GetFiles(folder);
			foreach (var file in files)
			{
				var serialized = File.ReadAllText(file);
				var deserialized = JsonConvert.DeserializeObject<T>(serialized);
				_collection.Add(deserialized);
			}
		}

		public IEnumerable<T> AsQueryable()
		{
			return _collection.AsQueryable();
		}

		public IEnumerable<T> Find(Predicate<T> query)
		{
			return _collection.Where(t => query(t));
		}

		public T1 GetItem<T1>(Guid key)
		{
			throw new NotImplementedException();
		}

		public bool InsertOne(T item)
		{
			throw new NotImplementedException();
		}

		public bool InsertMany(IEnumerable<T> items)
		{
			throw new NotImplementedException();
		}

		public bool ReplaceOne(Predicate<T> filter, T item, bool upsert = false)
		{
			throw new NotImplementedException();
		}

		public bool ReplaceMany(Predicate<T> filter, T item)
		{
			throw new NotImplementedException();
		}

		public bool DeleteOne(Predicate<T> filter)
		{
			throw new NotImplementedException();
		}

		public bool DeleteMany(Predicate<T> filter)
		{
			throw new NotImplementedException();
		}

		public bool UpdateOne(Predicate<T> filter, T item)
		{
			throw new NotImplementedException();
		}

		public bool UpdateMany(Predicate<T> filter, T item)
		{
			throw new NotImplementedException();
		}

		public int Count { get; set; }
		public void Reload()
		{
			throw new NotImplementedException();
		}
	}
}