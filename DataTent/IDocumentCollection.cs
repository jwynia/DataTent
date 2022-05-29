using System;
using System.Collections.Generic;

namespace DataTent
{
	public interface IDocumentCollection<T>
	{
		IEnumerable<T> AsQueryable();
		IEnumerable<T> Find(Predicate<T> query);
		T GetItem<T>(Guid key);
		bool InsertOne(T item);
		bool InsertMany(IEnumerable<T> items);
		bool ReplaceOne(Predicate<T> filter, T item, bool upsert = false);
		bool ReplaceMany(Predicate<T> filter, T item);
		bool DeleteOne(Predicate<T> filter);
		bool DeleteMany(Predicate<T> filter);
		bool UpdateOne(Predicate<T> filter, T item);
		bool UpdateMany(Predicate<T> filter, T item);
		int Count { get; }
		void Reload();
        
	}
}