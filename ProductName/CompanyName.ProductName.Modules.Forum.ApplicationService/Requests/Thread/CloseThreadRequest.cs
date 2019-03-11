using System;
using System.Collections.Generic;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public class CloseThreadRequest : BaseRequest
    {
        public Guid ThreadId { get; set; }
        public Dictionary<Guid, int> PostAuthorMarks { get; set; }
    }
}
