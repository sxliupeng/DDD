using System;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public class UpdateRoleRequest : UpdateDomainObjectRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public RoleDataType RoleType { get; set; }
        public long AllowMask { get; set; }
        public long DenyMask { get; set; }
    }
}
