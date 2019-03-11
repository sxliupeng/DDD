using System;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public interface IPostService
    {
        GetPagedDataReply<PostData> GetPagedPosts(GetPagedPostDataRequest request);
        GetDataReply<PostData> GetPost(GetDataRequest<Guid> request);
        BaseReply CreatePost(CreatePostRequest request);
        BaseReply UpdatePost(UpdatePostRequest request);
        BaseReply DeletePost(DeleteDomainObjectRequest<Guid> request);
    }
}
