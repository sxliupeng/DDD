using System;
using CompanyName.ProductName.Mvc.Common;
using System.Collections.Generic;
using CompanyName.ProductName.Modules.Forum.ApplicationServices;

namespace CompanyName.ProductName.Modules.Forum.Website.ViewData
{
    public class ThreadViewData : BaseViewData
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int Marks { get; set; }
        public Guid AuthorId { get; set; }
        public Guid AuthorName { get; set; }
        public Guid SectionId { get; set; }
        public int TotalPosts { get; set; }
        public int TotalViews { get; set; }
        public Guid MostRecentReplierId { get; set; }
        public string MostRecentReplierName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime StickDate { get; set; }
        public ThreadDataStatus Status { get; set; }
        public ThreadDataReleaseStatus ReleaseStatus { get; set; }
    }

    public class CreateThreadViewData : BaseViewData
    {
        [ResourceName("ThreadSubject")]
        [IsRequired]
        [MaxLength(64)]
        public string Subject { get; set; }

        [ResourceName("ThreadBody")]
        [IsRequired]
        public string Body { get; set; }

        [ResourceName("ThreadMarks")]
        [IsRequired]
        public int Marks { get; set; }
    }

    public class EditThreadViewData : BaseViewData
    {
        [IsRequired]
        public Guid Id { get; set; }

        [ResourceName("ThreadSubject")]
        [IsRequired]
        [MaxLength(64)]
        public string Subject { get; set; }

        [ResourceName("ThreadBody")]
        [IsRequired]
        public string Body { get; set; }

        [ResourceName("ThreadMarks")]
        [IsRequired]
        public int Marks { get; set; }
    }
}
