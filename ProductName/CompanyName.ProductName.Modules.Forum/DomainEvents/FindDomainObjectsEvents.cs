using System;
using CompanyName.ProductName.Modules.Forum.DomainObjects;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.DomainEvents
{
    public class FindGroupsEvent : FindDomainObjectsEvent<Group>
    {
        public string Subject { get; set; }
    }
    public class FindSectionsEvent : FindDomainObjectsEvent<Section>
    {
        public Guid GroupId { get; set; }
        public string Subject { get; set; }
    }
    public class FindPostsEvent : FindDomainObjectsEvent<Post>
    {
        public Guid ThreadId { get; set; }
    }
    public class FindUsersEvent : FindDomainObjectsEvent<User>
    {
        public string UserName { get; set; }
    }
}
