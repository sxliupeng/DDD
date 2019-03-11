using System;
using System.Collections.Generic;
using CompanyName.ProductName.Common;

namespace CompanyName.ProductName.Modules.Forum.Models
{
    public class User : AggregateRoot<User, Guid>
    {
        public User() { Key = Guid.NewGuid(); }

        public string UserName { get; set; }
        public string NickName { get; set; }
        public int TotalMarks { get; set; }
        public string AvatarFileName { get; set; }
        public byte[] AvatarContent { get; set; }
        public string Language { get; set; }
        public string SiteTheme { get; set; }
        public UserStatus UserStatus { get; set; }

        public IList<Role> Roles { get; set; }
    }
}
