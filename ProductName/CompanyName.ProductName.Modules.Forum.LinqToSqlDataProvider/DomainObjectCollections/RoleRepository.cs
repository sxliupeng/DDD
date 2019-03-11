using System;
using System.Data.Linq;
using System.Linq;
using CompanyName.ProductName.Common;
using CompanyName.ProductName.Modules.Forum.Models;
using CompanyName.ProductName.Modules.Forum.Repositories;

namespace CompanyName.ProductName.Modules.Forum.LinqToSqlDataProvider
{
    public class RoleRepository : IRoleRepository
    {
        private DataContext dataContext;

        public RoleRepository(IUnitOfWorkManager unitOfWorkManager)
        {
            this.dataContext = unitOfWorkManager as DataContext;
        }

        #region IRoleRepository Members

        public IPagedList<Role> GetPagedRoles(RoleRequest request)
        {
            return dataContext.GetTable<Role>().ResolveRequest(request).GetPageData(request.PageIndex, request.PageSize);
        }

        public Role GetRole(Guid roleId)
        {
            return dataContext.GetTable<Role>().Where(role => role.Id == roleId).FirstOrDefault();
        }

        public Role GetRole(string roleName)
        {
            return dataContext.GetTable<Role>().Where(role => role.Name == roleName).FirstOrDefault();
        }

        public void Add(Role role)
        {
            dataContext.GetTable<Role>().InsertOnSubmit(role);
        }

        #endregion
    }
}
