using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using CompanyName.ProductName.Modules.Forum.DomainObjects;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.LinqToSqlDataProvider
{
    public class ThreadCollection : DomainObjectCollection<Thread, Guid>
    {
        #region Private Variables

        private DataContext dataContext;
        private ITable<ThreadObject> threadTable;

        #endregion

        #region Constructors

        public ThreadCollection(IUnitOfWork unitOfWork, IDataContextProvider dataContextProvider)
        {
            dataContext = dataContextProvider.DataContext;
            unitOfWork.RegisterPersistableCollection(this);
            threadTable = dataContext.GetTable<ThreadObject>();
        }

        #endregion

        #region Collection Methods Overrides

        protected override Thread GetFromPersistence(Guid id)
        {
            var threadObj = threadTable.Where(t => t.Id == id).FirstOrDefault();
            if (threadObj != null)
            {
                return threadObj.ToThread();
            }
            return null;
        }
        protected override void PersistNewDomainObjects(List<Thread> newDomainObjects)
        {
            foreach (var newThread in newDomainObjects)
            {
                threadTable.InsertOnSubmit(newThread.ToThreadObject());
            }
        }
        protected override void PersistModifiedDomainObjects(List<Thread> modifiedDomainObjects)
        {
            foreach (var modifiedThread in modifiedDomainObjects)
            {
                var threadObj = threadTable.Where(t => t.Id == modifiedThread.Id).FirstOrDefault();
                if (threadObj != null)
                {
                    threadObj.UpdateAccordingWith(modifiedThread);
                }
            }
        }
        protected override void PersistRemovedDomainObjects(List<Thread> removedDomainObjects)
        {
            foreach (var removedThread in removedDomainObjects)
            {
                var threadObj = threadTable.Where(t => t.Id == removedThread.Id).FirstOrDefault();
                if (threadObj != null)
                {
                    threadTable.DeleteOnSubmit(threadObj);
                }
            }
        }

        #endregion
    }
}
