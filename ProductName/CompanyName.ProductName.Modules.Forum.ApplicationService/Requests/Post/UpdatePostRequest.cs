using System;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public class UpdatePostRequest : UpdateDomainObjectRequest<Guid>
    {
        public string Body { get; set; }
    }
}
