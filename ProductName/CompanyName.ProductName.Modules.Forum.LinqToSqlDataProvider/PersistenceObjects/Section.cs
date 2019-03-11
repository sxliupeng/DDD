using System;
using CompanyName.ProductName.Common;

namespace CompanyName.ProductName.Modules.Forum.Models
{
    public class Section : AggregateRoot<Section, Guid>
    {
        public Section()
        {
            Key = Guid.NewGuid();
            Enabled = true;
        }

        public string Subject { get; set; }
        public bool Enabled { get; set; }
        public Guid GroupId { get; set; }

        public int TotalThreads { get; set; }
    }
}
