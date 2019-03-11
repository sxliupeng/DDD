using System;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public class GetPagedGroupDataRequest : GetPagedDataRequest
    {
        public string Subject { get; set; }
        public bool? Enabled { get; set; }
    }
}
