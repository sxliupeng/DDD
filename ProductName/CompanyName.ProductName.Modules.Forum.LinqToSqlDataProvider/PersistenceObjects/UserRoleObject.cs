using System;
using System.Data.Linq.Mapping;

namespace CompanyName.ProductName.Modules.Forum.LinqToSqlDataProvider
{
    [Table(Name = "tb_UserRoles")]
    public class UserRoleObject
    {
        [Column(Name = "UserId", DbType = "UniqueIdentifier", IsPrimaryKey = true)]
        public Guid UserId { get; set; }
        [Column(Name = "RoleId", DbType = "UniqueIdentifier", IsPrimaryKey = true)]
        public Guid RoleId { get; set; }
    }
}
