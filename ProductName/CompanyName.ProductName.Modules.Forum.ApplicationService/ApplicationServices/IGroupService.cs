using System;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public interface IGroupService
    {
        GetDataListReply<GroupData> GetGroups(GetGroupDataListRequest request);
        GetPagedDataReply<GroupData> GetPagedGroups(GetPagedGroupDataRequest request);
        GetDataReply<GroupData> GetGroup(GetDataRequest<Guid> request);
        BaseReply CreateGroup(CreateGroupRequest request);
        BaseReply UpdateGroup(UpdateGroupRequest request);
    }
}
