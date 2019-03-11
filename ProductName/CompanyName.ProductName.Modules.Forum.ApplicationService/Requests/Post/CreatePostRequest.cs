using System;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public class CreatePostRequest : BaseRequest
    {
        public string Body { get; set; }
        public Guid ThreadId { get; set; }
        public Guid AuthorId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
