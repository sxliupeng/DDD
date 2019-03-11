using System;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public class GetPagedPostDataRequest : GetPagedDataRequest
    {
        public Guid ThreadId { get; set; }
    }
}
