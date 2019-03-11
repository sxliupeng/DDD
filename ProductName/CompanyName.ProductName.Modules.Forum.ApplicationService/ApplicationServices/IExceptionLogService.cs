using System;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public interface IExceptionLogService
    {
        GetPagedDataReply<ExceptionLogData> GetPagedExceptionLogs(GetPagedDataRequest request);
        GetDataReply<ExceptionLogData> GetExceptionLog(GetDataRequest<Guid> request);
        BaseReply CreateExceptionLog(CreateExceptionLogRequest request);
        BaseReply UpdateExceptionLog(UpdateExceptionLogRequest request);
        BaseReply DeleteExceptionLog(DeleteDomainObjectRequest<Guid> request);
    }
}
