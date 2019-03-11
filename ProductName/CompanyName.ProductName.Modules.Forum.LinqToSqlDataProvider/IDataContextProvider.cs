using System;
using System.Data.Linq;

namespace CompanyName.ProductName.Modules.Forum.LinqToSqlDataProvider
{
    public interface IDataContextProvider : IDisposable
    {
        DataContext DataContext { get; }
    }
}
