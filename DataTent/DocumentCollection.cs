using System;
using System.Collections.Generic;

namespace DataTent
{
	public class DocumentCollection<T>: IDocumentCollection<T>
	{
		public DocumentCollection(string folder)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<T> AsQueryable()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<T> Find(Predicate<T> query)
		{
			throw new NotImplementedException();
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