using System;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.DomainEvents
{
    public class ChangeSectionSubjectEvent : DomainEvent
    {
        public Guid SectionId { get; set; }
        public string NewSubject { get; set; }
    }
}
