using System;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.DomainEvents
{
    public class ChangeGroupSubjectEvent : DomainEvent
    {
        public Guid GroupId { get; set; }
        public string NewSubject { get; set; }
    }
}
