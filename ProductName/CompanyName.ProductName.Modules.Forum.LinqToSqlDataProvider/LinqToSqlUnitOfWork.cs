using System.Data.Linq;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.LinqToSqlDataProvider
{
    public class LinqToSqlUnitOfWork : UnitOfWork
    {
        private DataContext dataContext;

        public LinqToSqlUnitOfWork(IDataContextProvider dataContextProvider)
        {
            dataContext = dataContextProvider.DataContext;
        }

        public override void SubmitChanges()
        {
            foreach (IPersistableCollection persistableCollection in PersistableCollections)
            {
                persistableCollection.PersistChanges();
            }
            dataContext.SubmitChanges();
        }

        public override void Dispose()
        {
            dataContext.Dispose();
        }
    }
}
