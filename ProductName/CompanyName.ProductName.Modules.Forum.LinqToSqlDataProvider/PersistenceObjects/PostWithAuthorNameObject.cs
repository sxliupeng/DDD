using System;
using CompanyName.ProductName.Modules.Forum.DomainObjects;

namespace CompanyName.ProductName.Modules.Forum.LinqToSqlDataProvider
{
    public class PostWithAuthorNameObject
    {
        public PostObject Post { get; set; }
        public string AuthorName { get; set; }
    }
}
