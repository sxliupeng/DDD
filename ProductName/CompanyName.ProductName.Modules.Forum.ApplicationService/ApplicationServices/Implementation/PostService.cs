using System;
using CompanyName.ProductName.Modules.Forum.DomainObjects;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public class PostService : BaseService, IPostService
    {
        private IForumQueryService queryService;

        public PostService(IForumQueryService queryService)
        {
            this.queryService = queryService;
        }

        #region IPostService Members

        public GetPagedDataReply<PostData> GetPagedPosts(GetPagedPostDataRequest request)
        {
            return new GetPagedDataReply<PostData>
            {
                PageData = queryService.GetPagedPosts(
                    request.ThreadId,
                    request.PageIndex,
                    request.PageSize)
            };
        }

        public GetDataReply<PostData> GetPost(GetDataRequest<Guid> request)
        {
            return new GetDataReply<PostData>
            {
                Data = queryService.GetPost(request.Id)
            };
        }

        public BaseReply CreatePost(CreatePostRequest request)
        {
            return ProcessRequest(
                () =>
                {
                    Repository.Add(new Post(request.ThreadId, request.AuthorId, DateTime.Now) { Body = request.Body });
                });
        }

        public BaseReply UpdatePost(UpdatePostRequest request)
        {
            return ProcessRequest(
                () =>
                {
                    Repository.Get<Post, Guid>(request.Id).Body = request.Body;
                });
        }

        public BaseReply DeletePost(DeleteDomainObjectRequest<Guid> request)
        {
            return ProcessRequest(
                () =>
                {
                    Repository.Remove<Post, Guid>(request.Id);
                });
        }

        #endregion
    }
}
