using System;
using CompanyName.ProductName.Modules.Forum.DomainObjects;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public class RoleService : BaseService, IRoleService
    {
        private IForumQueryService queryService;

        public RoleService(IForumQueryService queryService)
        {
            this.queryService = queryService;
        }

        #region IRoleService Members

        public GetPagedDataReply<RoleData> GetPagedRoles(GetPagedDataRequest request)
        {
            return new GetPagedDataReply<RoleData>
            {
                PageData = queryService.GetPagedRoles(
                    request.PageIndex,
                    request.PageSize)
            };
        }

        public GetDataReply<RoleData> GetRole(GetDataRequest<Guid> request)
        {
            return new GetDataReply<RoleData>
            {
                Data = queryService.GetRole(request.Id)
            };
        }

        public BaseReply CreateRole(CreateRoleRequest request)
        {
            return ProcessRequest(
                () =>
                {
                    Repository.Add(new Role { Name = request.Name, Description = request.Description, RoleType = request.RoleType.ToRoleType() });
                });
        }

        public BaseReply UpdateRole(UpdateRoleRequest request)
        {
            return ProcessRequest(
                () =>
                {
                    var role = Repository.Get<Role, Guid>(request.Id);
                    role.Name = request.Name;
                    role.Description = request.Description;
                    role.RoleType = request.RoleType.ToRoleType();
                    role.AllowMask = request.AllowMask;
                    role.DenyMask = request.DenyMask;
                });
        }

        public BaseReply DeleteRole(DeleteDomainObjectRequest<Guid> request)
        {
            return ProcessRequest(
                () =>
                {
                    Repository.Remove<Role, Guid>(request.Id);
                });
        }

        #endregion
    }
}
