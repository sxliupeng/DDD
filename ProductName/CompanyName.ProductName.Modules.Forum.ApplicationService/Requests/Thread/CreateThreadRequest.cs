using System;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public class CreateThreadRequest : BaseRequest
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public Guid AuthorId { get; set; }
        public Guid SectionId { get; set; }
        public int Marks { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime StickDate { get; set; }
        public ThreadDataStatus Status { get; set; }
    }
}
