using System;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public class CreateExceptionLogRequest : BaseRequest
    {
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
