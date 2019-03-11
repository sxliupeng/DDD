using System;
using System.Collections.Generic;
using CompanyName.ProductName.Modules.Forum.DomainObjects;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.DomainEvents
{
    public class ThreadClosedEvent : DomainEvent
    {
        public Thread Thread { get; set; }
        public Dictionary<Guid, int> PostAuthorMarks { get; set; }
    }
}
