using System;
using CompanyName.ProductName.Modules.Forum.DomainObjects;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public class ExceptionLogService : BaseService, IExceptionLogService
    {
        private IForumQueryService queryService;

        public ExceptionLogService(IForumQueryService queryService)
        {
            this.queryService = queryService;
        }

        #region IExceptionLogService Members

        public GetPagedDataReply<ExceptionLogData> GetPagedExceptionLogs(GetPagedDataRequest request)
        {
            return new GetPagedDataReply<ExceptionLogData>
            {
                PageData = queryService.GetPagedExceptionLogs(
                    request.PageIndex,
                    request.PageSize)
            };
        }

        public GetDataReply<ExceptionLogData> GetExceptionLog(GetDataRequest<Guid> request)
        {
            return new GetDataReply<ExceptionLogData>
            {
                Data = queryService.GetExceptionLog(request.Id)
            };
        }

        public BaseReply CreateExceptionLog(CreateExceptionLogRequest request)
        {
            return ProcessRequest(
                () =>
                {
                    Repository.Add(new ExceptionLog
                                   {
                                       Message = request.Message,
                                       ExceptionDetails = request.ExceptionDetails,
                                       UserName = request.UserName,
                                       IPAddress = request.IPAddress,
                                       UserAgent = request.UserAgent,
                                       HttpReferrer = request.HttpReferrer,
                                       HttpVerb = request.HttpVerb,
                                       PathAndQuery = request.PathAndQuery,
                                       DateCreated = request.DateCreated,
                                       DateLastOccurred = request.DateLastOccurred,
                                       Frequency = request.Frequency
                                   });
                });
        }

        public BaseReply UpdateExceptionLog(UpdateExceptionLogRequest request)
        {
            return ProcessRequest(
                () =>
                {
                    var exceptionLog = Repository.Get<ExceptionLog, Guid>(request.Id);
                    exceptionLog.Message = request.Message;
                    exceptionLog.ExceptionDetails = request.ExceptionDetails;
                    exceptionLog.UserName = request.UserName;
                    exceptionLog.IPAddress = request.IPAddress;
                    exceptionLog.UserAgent = request.UserAgent;
                    exceptionLog.HttpReferrer = request.HttpReferrer;
                    exceptionLog.HttpVerb = request.HttpVerb;
                    exceptionLog.PathAndQuery = request.PathAndQuery;
                    exceptionLog.DateLastOccurred = request.DateLastOccurred;
                    exceptionLog.Frequency = request.Frequency;
                });
        }

        public BaseReply DeleteExceptionLog(DeleteDomainObjectRequest<Guid> request)
        {
            return ProcessRequest(
                () =>
                {
                    Repository.Remove<ExceptionLog, Guid>(request.Id);
                });
        }

        #endregion
    }
}
