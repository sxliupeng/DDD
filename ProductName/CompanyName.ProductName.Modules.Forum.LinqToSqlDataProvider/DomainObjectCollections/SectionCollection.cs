using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using CompanyName.ProductName.Modules.Forum.DomainEvents;
using CompanyName.ProductName.Modules.Forum.DomainObjects;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.LinqToSqlDataProvider
{
    public class SectionCollection : DomainObjectCollection<Section, Guid>
    {
        #region Private Variables

        private DataContext dataContext;
        private ITable<SectionObject> sectionTable;
        private ITable<SectionRoleUserObject> sectionRoleUserTable;

        #endregion

        #region Constructors

        public SectionCollection(IUnitOfWork unitOfWork, IDataContextProvider dataContextProvider)
        {
            dataContext = dataContextProvider.DataContext;
            unitOfWork.RegisterPersistableCollection(this);
            sectionTable = dataContext.GetTable<SectionObject>();
            sectionRoleUserTable = dataContext.GetTable<SectionRoleUserObject>();
        }

        #endregion

        #region Collection Methods Overrides

        protected override Section GetFromPersistence(Guid id)
        {
            var sectionObj = sectionTable.Where(s => s.Id == id).FirstOrDefault();
            if (sectionObj != null)
            {
                return sectionObj.ToSection();
            }
            return null;
        }
        protected override void PersistNewDomainObjects(List<Section> newDomainObjects)
        {
            foreach (var newSection in newDomainObjects)
            {
                sectionTable.InsertOnSubmit(newSection.ToSectionObject());
            }
        }
        protected override void PersistModifiedDomainObjects(List<Section> modifiedDomainObjects)
        {
            foreach (var modifiedSection in modifiedDomainObjects)
            {
                var sectionObj = sectionTable.Where(s => s.Id == modifiedSection.Id).FirstOrDefault();
                if (sectionObj != null)
                {
                    sectionObj.UpdateAccordingWith(modifiedSection);
                }
            }
        }

        #endregion

        #region Event Handlers

        public IList<Section> Handle(FindSectionsEvent evnt)
        {
            return GetDomainObjects(sectionTable.Where(s => s.Subject == evnt.Subject && s.GroupId == evnt.GroupId).ToSectionList(),
                                    s => s.Subject == evnt.Subject && s.GroupId == evnt.GroupId);
        }
        public void Handle(AddSectionRoleUserEvent evnt)
        {
            sectionRoleUserTable.InsertOnSubmit(new SectionRoleUserObject { SectionId = evnt.SectionId, RoleId = evnt.RoleId, UserId = evnt.UserId });
        }
        public void Handle(RemoveSectionRoleUserEvent evnt)
        {
            var sruObj = sectionRoleUserTable.Where(sru => sru.SectionId == evnt.SectionId && sru.RoleId == evnt.RoleId && sru.UserId == evnt.UserId).FirstOrDefault();
            if (sruObj != null)
            {
                sectionRoleUserTable.DeleteOnSubmit(sruObj);
            }
        }

        #endregion
    }
}
