using System;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public class GetPagedThreadDataRequest : GetPagedDataRequest
    {
        public string Subject { get; set; }
        public Guid SectionId { get; set; }
        public Guid AuthorId { get; set; }
        public Guid ReplierId { get; set; }
        public ThreadDataStatus? Status { get; set; }
        public ThreadDataReleaseStatus? ReleaseStatus { get; set; }
        public ThreadDataOrderType? OrderType { get; set; }
    }
}
