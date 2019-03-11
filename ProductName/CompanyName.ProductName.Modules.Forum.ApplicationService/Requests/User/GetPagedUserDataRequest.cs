using System;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public class GetPagedUserDataRequest : GetPagedDataRequest
    {
        public string NickName { get; set; }
        public int TotalMarks { get; set; }
        public string Language { get; set; }
        public string SiteTheme { get; set; }
        public UserDataStatus UserStatus { get; set; }
    }
}
