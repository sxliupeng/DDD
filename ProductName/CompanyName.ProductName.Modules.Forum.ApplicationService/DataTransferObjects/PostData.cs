using System;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public class PostData
    {
        public Guid Id { get; set; }
        public string Body { get; set; }
        public Guid ThreadId { get; set; }
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
