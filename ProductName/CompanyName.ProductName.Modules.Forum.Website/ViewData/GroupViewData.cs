using System;
using CompanyName.ProductName.Mvc.Common;

namespace CompanyName.ProductName.Modules.Forum.Website.ViewData
{
    public class GroupViewData : BaseViewData
    {
        [IsRequired]
        public Guid Id { get; set; }

        [ResourceName("GroupSubject")]
        [IsRequired]
        [MaxLength(64)]
        public string Subject { get; set; }

        [ResourceName("Enabled")]
        public bool Enabled { get; set; }
    }

    public class CreateGroupViewData : BaseViewData
    {
        [ResourceName("GroupSubject")]
        [IsRequired]
        [MaxLength(64)]
        public string Subject { get; set; }

        [ResourceName("Enabled")]
        public bool Enabled { get; set; }
    }
}
