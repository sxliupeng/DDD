using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using CompanyName.ProductName.Modules.Forum.DomainEvents;
using CompanyName.ProductName.Modules.Forum.DomainObjects;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.LinqToSqlDataProvider
{
    public class GroupCollection : DomainObjectCollection<Group, Guid>
    {
        #region Private Variables

        private DataContext dataContext;
        private ITable<GroupObject> groupTable;

        #endregion

        #region Constructors

        public GroupCollection(IUnitOfWork unitOfWork, IDataContextProvider dataContextProvider)
        {
            dataContext = dataContextProvider.DataContext;
            unitOfWork.RegisterPersistableCollection(this);
            groupTable = dataContext.GetTable<GroupObject>();
        }

        #endregion

        #region Collection Methods Overrides

        protected override Group GetFromPersistence(Guid id)
        {
            var groupObj = groupTable.Where(g => g.Id == id).FirstOrDefault();
            if (groupObj != null)
            {
                return groupObj.ToGroup();
            }
            return null;
        }
        protected override void PersistNewDomainObjects(List<Group> newDomainObjects)
        {
            foreach (var newGroup in newDomainObjects)
            {
                groupTable.InsertOnSubmit(newGroup.ToGroupObject());
            }
        }
        protected override void PersistModifiedDomainObjects(List<Group> modifiedDomainObjects)
        {
            foreach (var modifiedGroup in modifiedDomainObjects)
            {
                var groupObj = groupTable.Where(g => g.Id == modifiedGroup.Id).FirstOrDefault();
                if (groupObj != null)
                {
                    groupObj.UpdateAccordingWith(modifiedGroup);
                }
            }
        }

        #endregion

        #region Event Handlers

        public IList<Group> Handle(FindGroupsEvent evnt)
        {
            return GetDomainObjects(groupTable.Where(g => g.Subject == evnt.Subject).ToGroupList(),
                                    g => g.Subject == evnt.Subject);
        }

        #endregion
    }
}
