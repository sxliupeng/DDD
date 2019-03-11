using System;
using CompanyName.ProductName.Modules.Forum.DomainObjects;

namespace CompanyName.ProductName.Modules.Forum.LinqToSqlDataProvider
{
    public class ThreadWithAuthorAndReplyObject
    {
        public ThreadObject Thread { get; set; }
        public string AuthorName { get; set; }
        public string MostRecentReplierName { get; set; }
    }
}
