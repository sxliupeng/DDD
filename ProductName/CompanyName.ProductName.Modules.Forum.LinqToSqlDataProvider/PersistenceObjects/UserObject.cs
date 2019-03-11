using System;
using CompanyName.ProductName.Modules.Forum.DomainObjects;
using System.Data.Linq.Mapping;

namespace CompanyName.ProductName.Modules.Forum.LinqToSqlDataProvider
{
    [Table(Name = "tb_Users")]
    public class UserObject
    {
        [Column(Name = "Id", DbType = "UniqueIdentifier", IsPrimaryKey = true)]
        public Guid Id { get; set; }
        [Column(Name = "UserName", DbType = "NVarChar(64)", CanBeNull = false)]
        public string UserName { get; set; }
        [Column(Name = "NickName", DbType = "NVarChar(64)")]
        public string NickName { get; set; }
        [Column(Name = "AvatarFileName", DbType = "NVarChar(128)")]
        public string AvatarFileName { get; set; }
        [Column(Name = "AvatarContent", DbType = "VarBinary(MAX)")]
        public byte[] AvatarContent { get; set; }
        [Column(Name = "UserStatus", DbType = "Int")]
        public UserStatus UserStatus { get; set; }
        [Column(Name = "TotalMarks", DbType = "Int")]
        public int TotalMarks { get; set; }
        [Column(Name = "Language", DbType = "NVarChar(128)")]
        public string Language { get; set; }
        [Column(Name = "SiteTheme", DbType = "NVarChar(128)")]
        public string SiteTheme { get; set; }
    }
}
