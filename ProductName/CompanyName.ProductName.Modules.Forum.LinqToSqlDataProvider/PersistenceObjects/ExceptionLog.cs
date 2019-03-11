using System;
using CompanyName.ProductName.Common;

namespace CompanyName.ProductName.Modules.Forum.Models
{
    public class ExceptionLog : AggregateRoot<ExceptionLog, Guid>
    {
        public ExceptionLog()
        {
            Key = Guid.NewGuid();
        }

        public string Message { get; set; }
        public string ExceptionDetails { get; set; }
        public string UserName { get; set; }
        public string IPAddress { get; set; }
        public string UserAgent { get; set; }
        public string HttpReferrer { get; set; }
        public string HttpVerb { get; set; }
        public string PathAndQuery { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastOccurred { get; set; }
        public int Frequency { get; set; }
    }
}
