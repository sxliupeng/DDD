using System;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public interface IThreadService
    {
        GetPagedDataReply<ThreadData> GetPagedThreads(GetPagedThreadDataRequest request);
        GetDataReply<ThreadData> GetThread(GetDataRequest<Guid> request);
        BaseReply CreateThread(CreateThreadRequest request);
        BaseReply UpdateThread(UpdateThreadRequest request);
        BaseReply DeleteThread(DeleteDomainObjectRequest<Guid> request);
        BaseReply CloseThread(CloseThreadRequest request);
    }
}
