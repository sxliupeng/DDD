using System;
using CompanyName.ProductName.Common;

namespace CompanyName.ProductName.Modules.Forum.Models
{
    public class Post : AggregateRoot<Post, Guid>
    {
        public Post()
        {
            Key = Guid.NewGuid();
        }

        public string Body { get; set; }
        public Guid ThreadId { get; set; }
        public Guid AuthorId { get; set; }
        public DateTime CreateDate { get; set; }

        public Thread Thread { get; set; }
        public User Author { get; set; }
    }
}
