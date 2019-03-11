using System;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public class UpdateGroupRequest : UpdateDomainObjectRequest<Guid>
    {
        public string Subject { get; set; }
        public bool Enabled { get; set; }
    }
}
