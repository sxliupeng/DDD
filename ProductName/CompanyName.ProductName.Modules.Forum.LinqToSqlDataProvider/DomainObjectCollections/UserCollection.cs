using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using CompanyName.ProductName.Modules.Forum.DomainEvents;
using CompanyName.ProductName.Modules.Forum.DomainObjects;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.LinqToSqlDataProvider
{
    public class UserCollection : DomainObjectCollection<User, Guid>
    {
        #region Private Variables

        private DataContext dataContext;
        private ITable<UserObject> userTable;
        private ITable<UserRoleObject> userRoleTable;

        #endregion

        #region Constructors

        public UserCollection(IUnitOfWork unitOfWork, IDataContextProvider dataContextProvider)
        {
            dataContext = dataContextProvider.DataContext;
            unitOfWork.RegisterPersistableCollection(this);
            userTable = dataContext.GetTable<UserObject>();
            userRoleTable = dataContext.GetTable<UserRoleObject>();
        }

        #endregion

        #region Collection Methods Overrides

        protected override User GetFromPersistence(Guid id)
        {
            var userObj = userTable.Where(u => u.Id == id).FirstOrDefault();
            if (userObj != null)
            {
                return userObj.ToUser();
            }
            return null;
        }
        protected override void PersistNewDomainObjects(List<User> newDomainObjects)
        {
            foreach (var newUser in newDomainObjects)
            {
                userTable.InsertOnSubmit(newUser.ToUserObject());
            }
        }
        protected override void PersistModifiedDomainObjects(List<User> modifiedDomainObjects)
        {
            foreach (var modifiedUser in modifiedDomainObjects)
            {
                var userObj = userTable.Where(u => u.Id == modifiedUser.Id).FirstOrDefault();
                if (userObj != null)
                {
                    userObj.UpdateAccordingWith(modifiedUser);
                }
            }
        }
        protected override void PersistRemovedDomainObjects(List<User> removedDomainObjects)
        {
            foreach (var removedUser in removedDomainObjects)
            {
                var userObj = userTable.Where(u => u.Id == removedUser.Id).FirstOrDefault();
                if (userObj != null)
                {
                    userTable.DeleteOnSubmit(userObj);
                }
            }
        }

        #endregion

        #region Event Handlers

        public IList<User> Handle(FindUsersEvent evnt)
        {
            return GetDomainObjects(userTable.Where(u => u.UserName == evnt.UserName).ToUserList(),
                                    u => u.UserName == evnt.UserName);
        }
        public void Handle(AddUserRoleEvent evnt)
        {
            userRoleTable.InsertOnSubmit(new UserRoleObject { UserId = evnt.UserId, RoleId = evnt.RoleId });
        }
        public void Handle(RemoveUserRoleEvent evnt)
        {
            var userRoleObj = userRoleTable.Where(ur => ur.UserId == evnt.UserId && ur.RoleId == evnt.RoleId).FirstOrDefault();
            if (userRoleObj != null)
            {
                userRoleTable.DeleteOnSubmit(userRoleObj);
            }
        }

        #endregion
    }
}
