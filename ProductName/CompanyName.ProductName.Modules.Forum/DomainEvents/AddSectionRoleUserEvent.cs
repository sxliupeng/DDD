using System;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.DomainEvents
{
    public class AddSectionRoleUserEvent : DomainEvent
    {
        public Guid SectionId { get; set; }
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }
    }
}
