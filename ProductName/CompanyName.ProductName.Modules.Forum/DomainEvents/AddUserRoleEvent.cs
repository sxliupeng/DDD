using System;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.DomainEvents
{
    public class AddUserRoleEvent : DomainEvent
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
