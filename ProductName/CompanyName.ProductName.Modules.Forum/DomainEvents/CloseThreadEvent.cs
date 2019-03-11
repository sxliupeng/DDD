using System;
using System.Collections.Generic;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.DomainEvents
{
    public class CloseThreadEvent : DomainEvent
    {
        public Guid ThreadId { get; set; }
        public Dictionary<Guid, int> PostAuthorMarks { get; set; }
    }
}
