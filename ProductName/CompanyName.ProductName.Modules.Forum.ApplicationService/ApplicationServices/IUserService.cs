using System;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public interface IUserService
    {
        GetPagedDataReply<UserData> GetPagedUsers(GetPagedUserDataRequest request);
        GetDataReply<UserData> GetUser(GetDataRequest<Guid> request);
        BaseReply CreateUser(CreateUserRequest request);
        BaseReply UpdateUser(UpdateUserRequest request);
        BaseReply AddUserRole(AddUserRoleRequest request);
        BaseReply RemoveUserRole(RemoveUserRoleRequest request);
    }
}
