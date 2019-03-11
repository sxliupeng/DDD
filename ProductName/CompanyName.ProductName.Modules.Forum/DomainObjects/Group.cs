using System;
using System.Collections.Generic;
using System.Linq;
using CompanyName.ProductName.Modules.Forum.DomainEvents;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.DomainObjects
{
    public class Group : DomainObject<Guid>
    {
        #region Constructors

        public Group(string subject)
            : this(Guid.NewGuid(), subject)
        {
        }
        public Group(Guid id, string subject)
            : base(id)
        {
            this.Subject = subject;
        }

        #endregion

        #region Public Properties

        [TrackingProperty]
        public string Subject { get; set; }
        [TrackingProperty]
        public bool Enabled { get; set; }

        #endregion

        #region Event Handlers

        public void Handle(ChangeGroupSubjectEvent evnt)
        {
            if (this.Subject != evnt.NewSubject)
            {
                //Validate the new subject before update the subject.
                IList<Group> groups = Repository.Find<Group, FindGroupsEvent>(e => e.Subject = evnt.NewSubject);
                if (groups != null && groups.Count > 0 && groups.Any(g => g.Id != evnt.GroupId))
                {
                    throw new DuplicatedNameException(ForumValidationError.DuplicateGroupSubject.GetName(), evnt.NewSubject);
                }

                //Update the subject.
                this.Subject = evnt.NewSubject;
            }
        }

        #endregion
    }
}
