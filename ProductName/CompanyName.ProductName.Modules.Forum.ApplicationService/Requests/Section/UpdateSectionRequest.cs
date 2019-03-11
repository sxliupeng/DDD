using System;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public class UpdateSectionRequest : UpdateDomainObjectRequest<Guid>
    {
        public string Subject { get; set; }
        public bool Enabled { get; set; }
        public Guid GroupId { get; set; }
    }
}
