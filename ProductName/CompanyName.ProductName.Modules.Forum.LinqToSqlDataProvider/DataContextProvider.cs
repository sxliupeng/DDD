using System.Configuration;
using System.Data.Linq;

namespace CompanyName.ProductName.Modules.Forum.LinqToSqlDataProvider
{
    public class DataContextProvider : IDataContextProvider
    {
        private readonly DataContext dataContext;

        public DataContextProvider()
        {
            dataContext = new DataContext(ConfigurationManager.AppSettings["CompanyName.ProductName.Modules.Forum.ConnectionString"]);
        }

        #region IDataContextProvider Members

        public DataContext DataContext
        {
            get
            {
                return dataContext;
            }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            dataContext.Dispose();
        }

        #endregion
    }
}