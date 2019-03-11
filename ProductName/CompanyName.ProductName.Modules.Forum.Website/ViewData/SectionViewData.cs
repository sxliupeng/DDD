using System;
using CompanyName.ProductName.Mvc.Common;
using System.Collections.Generic;
using CompanyName.ProductName.Modules.Forum.ApplicationServices;

namespace CompanyName.ProductName.Modules.Forum.Website.ViewData
{
    public class SectionViewData : BaseViewData
    {
        [IsRequired]
        public Guid Id { get; set; }

        [ResourceName("SectionSubject")]
        [IsRequired]
        [MaxLength(64)]
        public string Subject { get; set; }

        [ResourceName("Enabled")]
        public bool Enabled { get; set; }

        [IsRequired]
        public Guid GroupId { get; set; }

        [ResourceName("GroupSubject")]
        [IsRequired]
        [MaxLength(64)]
        public string GroupSubject { get; set; }
    }

    public class CreateSectionViewData : BaseViewData
    {
        [ResourceName("SectionSubject")]
        [IsRequired]
        [MaxLength(64)]
        public string Subject { get; set; }

        [ResourceName("Enabled")]
        [IsRequired]
        public bool Enabled { get; set; }

        [ResourceName("SectionGroups")]
        [IsRequired]
        public Guid GroupId { get; set; }

        [ResourceName("SectionGroups")]
        public List<GroupData> Groups { get; set; }
    }

    public class EditSectionViewData : BaseViewData
    {
        [IsRequired]
        public Guid Id { get; set; }

        [ResourceName("SectionSubject")]
        [IsRequired]
        [MaxLength(64)]
        public string Subject { get; set; }

        [ResourceName("Enabled")]
        [IsRequired]
        public bool Enabled { get; set; }

        [ResourceName("SectionGroups")]
        [IsRequired]
        public Guid GroupId { get; set; }

        [ResourceName("SectionGroups")]
        public List<GroupData> Groups { get; set; }
    }
}
