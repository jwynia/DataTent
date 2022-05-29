using System;

namespace DataTent
{
	public interface IDataStore : IDisposable
	{
		IDocumentCollection<T> GetCollection<T>() where T : class;
		
	}
}