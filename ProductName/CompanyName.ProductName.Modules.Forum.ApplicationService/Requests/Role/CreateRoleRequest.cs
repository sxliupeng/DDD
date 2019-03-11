using System;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public class CreateRoleRequest : BaseRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public RoleDataType RoleType { get; set; }
    }
}
