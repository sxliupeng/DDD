using System;
using System.Data.Linq;
using System.Linq;
using CompanyName.ProductName.Common;
using CompanyName.ProductName.Modules.Forum.Models;
using CompanyName.ProductName.Modules.Forum.Repositories;

namespace CompanyName.ProductName.Modules.Forum.LinqToSqlDataProvider
{
    public class ExceptionLogRepository : IExceptionLogRepository
    {
        private DataContext dataContext;

        public ExceptionLogRepository(IUnitOfWorkManager unitOfWorkManager)
        {
            this.dataContext = unitOfWorkManager as DataContext;
        }

        #region IExceptionLogRepository Members

        public IPagedList<ExceptionLog> GetPagedExceptionLogs(ExceptionLogRequest request)
        {
            return dataContext.GetTable<ExceptionLog>().ResolveRequest(request).GetPageData(request.PageIndex, request.PageSize);
        }

        public ExceptionLog GetExceptionLog(Guid exceptionLogId)
        {
            return dataContext.GetTable<ExceptionLog>().Where(exceptionLog => exceptionLog.Id == exceptionLogId).FirstOrDefault();
        }

        public void Add(ExceptionLog exceptionLog)
        {
            dataContext.GetTable<ExceptionLog>().InsertOnSubmit(exceptionLog);
        }

        public void Remove(ExceptionLog exceptionLog)
        {
            dataContext.GetTable<ExceptionLog>().DeleteOnSubmit(exceptionLog);
        }

        #endregion
    }
}
