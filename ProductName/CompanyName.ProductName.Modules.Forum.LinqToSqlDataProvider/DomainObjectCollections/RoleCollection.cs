using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using CompanyName.ProductName.Modules.Forum.DomainObjects;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.LinqToSqlDataProvider
{
    public class RoleCollection : DomainObjectCollection<Role, Guid>
    {
        #region Private Variables

        private DataContext dataContext;
        private ITable<RoleObject> roleTable;

        #endregion

        #region Constructors

        public RoleCollection(IUnitOfWork unitOfWork, IDataContextProvider dataContextProvider)
        {
            dataContext = dataContextProvider.DataContext;
            unitOfWork.RegisterPersistableCollection(this);
            roleTable = dataContext.GetTable<RoleObject>();
        }

        #endregion

        #region Collection Methods Overrides

        protected override Role GetFromPersistence(Guid id)
        {
            var roleObj = roleTable.Where(u => u.Id == id).FirstOrDefault();
            if (roleObj != null)
            {
                return roleObj.ToRole();
            }
            return null;
        }
        protected override void PersistNewDomainObjects(List<Role> newDomainObjects)
        {
            foreach (var newRole in newDomainObjects)
            {
                roleTable.InsertOnSubmit(newRole.ToRoleObject());
            }
        }
        protected override void PersistModifiedDomainObjects(List<Role> modifiedDomainObjects)
        {
            foreach (var modifiedRole in modifiedDomainObjects)
            {
                var roleObj = roleTable.Where(r => r.Id == modifiedRole.Id).FirstOrDefault();
                if (roleObj != null)
                {
                    roleObj.UpdateAccordingWith(modifiedRole);
                }
            }
        }
        protected override void PersistRemovedDomainObjects(List<Role> removedDomainObjects)
        {
            foreach (var removedRole in removedDomainObjects)
            {
                var roleObj = roleTable.Where(r => r.Id == removedRole.Id).FirstOrDefault();
                if (roleObj != null)
                {
                    roleTable.DeleteOnSubmit(roleObj);
                }
            }
        }

        #endregion
    }
}
