using System;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public class SectionData
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public bool Enabled { get; set; }
        public Guid GroupId { get; set; }
        public string GroupSubject { get; set; }
    }
}
