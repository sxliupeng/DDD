using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using CompanyName.ProductName.Common;
using CompanyName.ProductName.Modules.Forum.Models;
using CompanyName.ProductName.Modules.Forum.Repositories;

namespace CompanyName.ProductName.Modules.Forum.LinqToSqlDataProvider
{
    public class UserRepository : IUserRepository
    {
        private DataContext dataContext;

        public UserRepository(IUnitOfWorkManager unitOfWorkManager)
        {
            this.dataContext = unitOfWorkManager as DataContext;
        }

        #region IUserRepository Members

        public void Add(User user)
        {
            dataContext.GetTable<User>().InsertOnSubmit(user);
        }

        public IPagedList<User> GetPagedUsers(UserRequest request)
        {
            return dataContext.GetTable<User>().ResolveRequest(request).GetPageData(request.PageIndex, request.PageSize);
        }

        public User GetUser(Guid userId)
        {
            return dataContext.GetTable<User>().Where(user => user.Id == userId).FirstOrDefault();
        }

        public User GetUser(string userName)
        {
            return dataContext.GetTable<User>().Where(user => user.UserName == userName).FirstOrDefault();
        }

        public IList<Role> GetUserRoles(Guid userId)
        {
            var roleQuery = dataContext.GetTable<Role>();
            var userRoleQuery = dataContext.GetTable<UserRole>();
            var userQuery = dataContext.GetTable<User>();

            return (from user in userQuery
                    join userRole in userRoleQuery on user.Id equals userRole.UserId
                    join role in roleQuery on userRole.RoleId equals role.Id
                    where user.Id == userId
                    select role).ToList();
        }

        public IList<User> GetRoleUsers(Guid roleId)
        {
            var roleQuery = dataContext.GetTable<Role>();
            var userRoleQuery = dataContext.GetTable<UserRole>();
            var userQuery = dataContext.GetTable<User>();

            return (from user in userQuery
                    join userRole in userRoleQuery on user.Id equals userRole.UserId
                    join role in roleQuery on userRole.RoleId equals role.Id
                    where role.Id == roleId
                    select user).ToList();
        }

        public IPagedList<User> GetRoleUsers(Guid roleId, int pageIndex, int pageSize)
        {
            var roleQuery = dataContext.GetTable<Role>();
            var userRoleQuery = dataContext.GetTable<UserRole>();
            var userQuery = dataContext.GetTable<User>();

            return (from user in userQuery
                    join userRole in userRoleQuery on user.Id equals userRole.UserId
                    join role in roleQuery on userRole.RoleId equals role.Id
                    where role.Id == roleId
                    select user).GetPageData(pageIndex, pageSize);
        }

        public bool IsUserInRole(Guid userId, Guid roleId)
        {
            return (from userRole in dataContext.GetTable<UserRole>() where userRole.UserId == userId && userRole.RoleId == roleId select userRole).Count() > 0;
        }

        public void AddUserToRole(Guid userId, Guid roleId)
        {
            dataContext.GetTable<UserRole>().InsertOnSubmit(new UserRole() { UserId = userId, RoleId = roleId });
        }

        public void RemoveUserFromRole(Guid userId, Guid roleId)
        {
            var userRoleToRemove = (from userRole in dataContext.GetTable<UserRole>() where userRole.UserId == userId && userRole.RoleId == roleId select userRole).FirstOrDefault();
            if (userRoleToRemove != null)
            {
                dataContext.GetTable<UserRole>().DeleteOnSubmit(userRoleToRemove);
            }
        }

        public void RemoveUserRoles(Guid userId)
        {
            var query = from userRole in dataContext.GetTable<UserRole>() where userRole.UserId == userId select userRole;
            dataContext.GetTable<UserRole>().DeleteAllOnSubmit(query.ToList());
        }

        #endregion
    }
}
