using System;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public class UpdateThreadRequest : UpdateDomainObjectRequest<Guid>
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public Guid SectionId { get; set; }
        public int TotalViews { get; set; }
        public int Marks { get; set; }
        public DateTime StickDate { get; set; }
        public ThreadDataStatus Status { get; set; }
    }
}
