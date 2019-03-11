using System;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public interface IRoleService
    {
        GetPagedDataReply<RoleData> GetPagedRoles(GetPagedDataRequest request);
        GetDataReply<RoleData> GetRole(GetDataRequest<Guid> request);
        BaseReply CreateRole(CreateRoleRequest request);
        BaseReply UpdateRole(UpdateRoleRequest request);
        BaseReply DeleteRole(DeleteDomainObjectRequest<Guid> request);
    }
}
