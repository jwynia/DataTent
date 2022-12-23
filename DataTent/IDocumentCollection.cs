using System;
using System.Collections.Generic;
using System.Linq;

namespace DataTent
{
	public interface IDocumentCollection<T>
	{
		IQueryable<T> AsQueryable();
		IEnumerable<T> Find(Predicate<T> query);
		bool Insert(T item, string uniqueId);
		bool Replace(T item, string uniqueId);
		bool Delete(string uniqueId);
		int Count { get; }
		void Reload();
        
	}
}