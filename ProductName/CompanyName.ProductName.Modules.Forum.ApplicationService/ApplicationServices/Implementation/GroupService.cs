using System;
using CompanyName.ProductName.Modules.Forum.DomainEvents;
using CompanyName.ProductName.Modules.Forum.DomainObjects;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public class GroupService : BaseService, IGroupService
    {
        private IForumQueryService queryService;

        public GroupService(IForumQueryService queryService)
        {
            this.queryService = queryService;
        }

        public GetDataListReply<GroupData> GetGroups(GetGroupDataListRequest request)
        {
            return new GetDataListReply<GroupData>
            {
                DataList = queryService.GetGroups(request.Subject, request.Enabled)
            };
        }
        public GetPagedDataReply<GroupData> GetPagedGroups(GetPagedGroupDataRequest request)
        {
            return new GetPagedDataReply<GroupData>
            {
                PageData = queryService.GetPagedGroups(request.Subject, request.Enabled, request.PageIndex, request.PageSize)
            };
        }
        public GetDataReply<GroupData> GetGroup(GetDataRequest<Guid> request)
        {
            return new GetDataReply<GroupData>
            {
                Data = queryService.GetGroup(request.Id)
            };
        }
        public BaseReply CreateGroup(CreateGroupRequest request)
        {
            return ProcessRequest(
                () =>
                {
                    Repository.Add(new Group(request.Subject) { Enabled = request.Enabled });
                });
        }
        public BaseReply UpdateGroup(UpdateGroupRequest request)
        {
            return ProcessRequest(
                () =>
                {
                    var group = Repository.Get<Group, Guid>(request.Id);
                    EventProcesser.ProcessEvent(new ChangeGroupSubjectEvent { GroupId = request.Id, NewSubject = request.Subject });
                    group.Enabled = request.Enabled;
                });
        }
    }
}
