using System;
using CompanyName.ProductName.Modules.Forum.DomainEvents;
using CompanyName.ProductName.Modules.Forum.DomainObjects;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public class UserService : BaseService, IUserService
    {
        private IForumQueryService queryService;

        public UserService(IForumQueryService queryService)
        {
            this.queryService = queryService;
        }

        #region IUserService Members

        public GetPagedDataReply<UserData> GetPagedUsers(GetPagedUserDataRequest request)
        {
            return new GetPagedDataReply<UserData>
            {
                PageData = queryService.GetPagedUsers(
                    request.NickName,
                    request.TotalMarks,
                    request.Language,
                    request.SiteTheme,
                    request.UserStatus.ToUserType(),
                    request.PageIndex,
                    request.PageSize)
            };
        }
        public GetDataReply<UserData> GetUser(GetDataRequest<Guid> request)
        {
            return new GetDataReply<UserData>
            {
                Data = queryService.GetUser(request.Id)
            };
        }
        public BaseReply CreateUser(CreateUserRequest request)
        {
            return ProcessRequest(
                () =>
                {
                    Repository.Add(
                        new User(request.UserName) {
                            NickName = request.NickName,
                            TotalMarks = request.TotalMarks,
                            AvatarFileName = request.AvatarFileName,
                            AvatarContent = request.AvatarContent,
                            Language = request.Language,
                            SiteTheme = request.SiteTheme,
                            UserStatus = UserStatus.Normal
                        });
                });
        }
        public BaseReply UpdateUser(UpdateUserRequest request)
        {
            return ProcessRequest(
                () =>
                {
                    var user = Repository.Get<User, Guid>(request.Id);
                    user.NickName = request.NickName;
                    user.TotalMarks = request.TotalMarks;
                    user.AvatarFileName = request.AvatarFileName;
                    user.AvatarContent = request.AvatarContent;
                    user.Language = request.Language;
                    user.SiteTheme = request.SiteTheme;
                    user.UserStatus = request.UserStatus.ToUserType();
                });
        }
        public BaseReply AddUserRole(AddUserRoleRequest request)
        {
            return ProcessRequest(
                () =>
                {
                    EventProcesser.ProcessEvent(new AddUserRoleEvent { UserId = request.UserId, RoleId = request.RoleId });
                });
        }
        public BaseReply RemoveUserRole(RemoveUserRoleRequest request)
        {
            return ProcessRequest(
                () =>
                {
                    EventProcesser.ProcessEvent(new RemoveUserRoleEvent { UserId = request.UserId, RoleId = request.RoleId });
                });
        }

        #endregion
    }
}
