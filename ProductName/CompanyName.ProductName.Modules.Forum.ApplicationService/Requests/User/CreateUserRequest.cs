using System;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public class CreateUserRequest : BaseRequest
    {
        public string UserName { get; set; }
        public string NickName { get; set; }
        public int TotalMarks { get; set; }
        public string AvatarFileName { get; set; }
        public byte[] AvatarContent { get; set; }
        public string Language { get; set; }
        public string SiteTheme { get; set; }
        public UserDataStatus UserStatus { get; set; }
    }
}
