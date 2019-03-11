using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using CompanyName.ProductName.Modules.Forum.DomainObjects;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.LinqToSqlDataProvider
{
    public class ExceptionLogCollection : DomainObjectCollection<ExceptionLog, Guid>
    {
        #region Private Variables

        private DataContext dataContext;
        private ITable<ExceptionLogObject> exceptionLogTable;

        #endregion

        #region Constructors

        public ExceptionLogCollection(IUnitOfWork unitOfWork, IDataContextProvider dataContextProvider)
        {
            dataContext = dataContextProvider.DataContext;
            unitOfWork.RegisterPersistableCollection(this);
            exceptionLogTable = dataContext.GetTable<ExceptionLogObject>();
        }

        #endregion

        #region Collection Methods Overrides

        protected override ExceptionLog GetFromPersistence(Guid id)
        {
            var exceptionLogObj = exceptionLogTable.Where(el => el.Id == id).FirstOrDefault();
            if (exceptionLogObj != null)
            {
                return exceptionLogObj.ToExceptionLog();
            }
            return null;
        }
        protected override void PersistNewDomainObjects(List<ExceptionLog> newDomainObjects)
        {
            foreach (var newExceptionLog in newDomainObjects)
            {
                exceptionLogTable.InsertOnSubmit(newExceptionLog.ToExceptionLogObject());
            }
        }
        protected override void PersistModifiedDomainObjects(List<ExceptionLog> modifiedDomainObjects)
        {
            foreach (var modifiedExceptionLog in modifiedDomainObjects)
            {
                var exceptionLogObj = exceptionLogTable.Where(el => el.Id == modifiedExceptionLog.Id).FirstOrDefault();
                if (exceptionLogObj != null)
                {
                    exceptionLogObj.UpdateAccordingWith(modifiedExceptionLog);
                }
            }
        }
        protected override void PersistRemovedDomainObjects(List<ExceptionLog> removedDomainObjects)
        {
            foreach (var removedExceptionLog in removedDomainObjects)
            {
                var exceptionLogObj = exceptionLogTable.Where(el => el.Id == removedExceptionLog.Id).FirstOrDefault();
                if (exceptionLogObj != null)
                {
                    exceptionLogTable.DeleteOnSubmit(exceptionLogObj);
                }
            }
        }

        #endregion
    }
}
