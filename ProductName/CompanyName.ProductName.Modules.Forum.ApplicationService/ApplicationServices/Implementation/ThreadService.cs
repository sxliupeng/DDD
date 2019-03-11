using System;
using CompanyName.ProductName.Modules.Forum.DomainEvents;
using CompanyName.ProductName.Modules.Forum.DomainObjects;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public class ThreadService : BaseService, IThreadService
    {
        private IForumQueryService queryService;

        public ThreadService(IForumQueryService queryService)
        {
            this.queryService = queryService;
        }

        public GetPagedDataReply<ThreadData> GetPagedThreads(GetPagedThreadDataRequest request)
        {
            return new GetPagedDataReply<ThreadData>
            {
                PageData = queryService.GetPagedThreads(
                    request.SectionId,
                    request.AuthorId,
                    request.Subject,
                    request.ReplierId,
                    request.Status,
                    request.ReleaseStatus,
                    request.OrderType,
                    request.PageIndex,
                    request.PageSize)
            };
        }
        public GetDataReply<ThreadData> GetThread(GetDataRequest<Guid> request)
        {
            return new GetDataReply<ThreadData>
            {
                Data = queryService.GetThread(request.Id)
            };
        }
        public BaseReply CreateThread(CreateThreadRequest request)
        {
            return ProcessRequest(
                () =>
                {
                    Repository.Add(new Thread(request.SectionId, request.AuthorId, request.Marks, DateTime.Now) { Subject = request.Subject, Body = request.Body });
                });
        }
        public BaseReply UpdateThread(UpdateThreadRequest request)
        {
            return ProcessRequest(
                () =>
                {
                    var thread = Repository.Get<Thread, Guid>(request.Id);
                    thread.Subject = request.Subject;
                    thread.Body = request.Body;
                    thread.SectionId = request.SectionId;
                    thread.TotalViews = request.TotalViews;
                    thread.Marks = request.Marks;
                    thread.StickDate = request.StickDate;
                    thread.Status = request.Status.ToThreadStatus();
                });
        }
        public BaseReply DeleteThread(DeleteDomainObjectRequest<Guid> request)
        {
            return ProcessRequest(
                () =>
                {
                    Repository.Remove<Thread, Guid>(request.Id);
                });
        }
        public BaseReply CloseThread(CloseThreadRequest request)
        {
            return ProcessRequest(
                () =>
                {
                    EventProcesser.ProcessEvent(new CloseThreadEvent { ThreadId = request.ThreadId, PostAuthorMarks = request.PostAuthorMarks });
                });
        }
    }
}
