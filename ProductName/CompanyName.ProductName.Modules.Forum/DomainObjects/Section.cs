using System;
using System.Collections.Generic;
using System.Linq;
using CompanyName.ProductName.Modules.Forum.DomainEvents;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.DomainObjects
{
    public class Section : DomainObject<Guid>
    {
        #region Constructors

        public Section(Guid groupId, string subject)
            : this(Guid.NewGuid(), groupId, subject)
        {
        }
        public Section(Guid id, Guid groupId, string subject)
            : base(id)
        {
            this.GroupId = groupId;
            this.Subject = subject;
        }

        #endregion

        #region Public Properties

        [TrackingProperty]
        public string Subject { get; set; }
        [TrackingProperty]
        public bool Enabled { get; set; }
        [TrackingProperty]
        public Guid GroupId { get; set; }

        #endregion

        #region Event Handlers

        public void Handle(ChangeSectionSubjectEvent evnt)
        {
            if (this.Subject != evnt.NewSubject)
            {
                //Validate the new subject before update the subject.
                IList<Section> sections = Repository.Find<Section, FindSectionsEvent>(
                e =>
                {
                    e.GroupId = this.GroupId;
                    e.Subject = evnt.NewSubject;
                });
                if (sections != null && sections.Count > 0 && sections.Any(s => s.Id != evnt.SectionId))
                {
                    throw new DuplicatedNameException(ForumValidationError.DuplicateSectionSubject.GetName(), evnt.NewSubject);
                }

                //Update the subject.
                this.Subject = evnt.NewSubject;
            }
        }

        #endregion
    }
}
