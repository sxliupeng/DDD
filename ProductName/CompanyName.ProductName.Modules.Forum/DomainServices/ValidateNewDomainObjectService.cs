using System.Collections.Generic;
using CompanyName.ProductName.Modules.Forum.DomainEvents;
using CompanyName.ProductName.Modules.Forum.DomainObjects;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.DomainServices
{
    public class ValidateNewDomainObjectService
    {
        private void Handle(PreAddDomainObjectEvent<Group> evnt)
        {
            IList<Group> existingGroups = Repository.Find<Group, FindGroupsEvent>(e => e.Subject = evnt.DomainObject.Subject);
            if (existingGroups != null && existingGroups.Count > 0)
            {
                throw new DuplicatedNameException(ForumValidationError.DuplicateGroupSubject.GetName(), evnt.DomainObject.Subject);
            }
        }
        private void Handle(PreAddDomainObjectEvent<Section> evnt)
        {
            IList<Section> existingSections = Repository.Find<Section, FindSectionsEvent>(
            e =>
            {
                e.GroupId = evnt.DomainObject.GroupId;
                e.Subject = evnt.DomainObject.Subject;
            });
            if (existingSections != null && existingSections.Count > 0)
            {
                throw new DuplicatedNameException(ForumValidationError.DuplicateSectionSubject.GetName(), evnt.DomainObject.Subject);
            }
        }
        private void Handle(PreAddDomainObjectEvent<User> evnt)
        {
            IList<User> existingUsers = Repository.Find<User, FindUsersEvent>(evt => evt.UserName = evnt.DomainObject.UserName);
            if (existingUsers != null && existingUsers.Count > 0)
            {
                throw new DuplicatedNameException(ForumValidationError.DuplicateUserName.GetName(), evnt.DomainObject.UserName);
            }
        }
    }
}
