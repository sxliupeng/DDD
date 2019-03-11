using System;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public class UserData
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public int TotalMarks { get; set; }
        public string AvatarFileName { get; set; }
        public byte[] AvatarContent { get; set; }
        public string Language { get; set; }
        public string SiteTheme { get; set; }
        public UserDataStatus UserStatus { get; set; }
    }

    public enum UserDataStatus
    {
        Normal = 1,  //正常用户
        Locked = 2,  //冻结用户
    }
}
