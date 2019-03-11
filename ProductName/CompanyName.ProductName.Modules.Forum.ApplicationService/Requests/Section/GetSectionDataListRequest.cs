using System;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public class GetSectionDataListRequest : BaseRequest
    {
        public string Subject { get; set; }
        public bool? Enabled { get; set; }
        public Guid GroupId { get; set; }
    }
}
