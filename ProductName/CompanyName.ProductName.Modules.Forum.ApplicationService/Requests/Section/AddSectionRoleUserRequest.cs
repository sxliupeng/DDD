using System;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public class AddSectionRoleUserRequest : BaseRequest
    {
        public Guid SectionId { get; set; }
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }
    }
}
