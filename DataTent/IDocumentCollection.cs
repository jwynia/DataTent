using System;
using System.Collections.Generic;
using System.Linq;

namespace DataTent
{
	public interface IDocumentCollection<T>
	{
		IQueryable<T> AsQueryable();
		IEnumerable<T> Find(Predicate<T> query);
		bool InsertOne(T item, string uniqueId);
		bool ReplaceOne(T item, string uniqueId);
		bool DeleteOne(string uniqueId);
		int Count { get; }
		void Reload();
        
	}
}