using System;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.DomainEvents
{
    public class RemoveUserRoleEvent : DomainEvent
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
