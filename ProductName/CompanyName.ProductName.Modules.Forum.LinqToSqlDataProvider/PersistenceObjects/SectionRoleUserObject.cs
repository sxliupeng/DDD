using System;
using System.Data.Linq.Mapping;

namespace CompanyName.ProductName.Modules.Forum.LinqToSqlDataProvider
{
    [Table(Name = "tb_SectionRoleUsers")]
    public class SectionRoleUserObject
    {
        [Column(Name = "SectionId", DbType = "UniqueIdentifier", IsPrimaryKey = true)]
        public Guid SectionId { get; set; }
        [Column(Name = "RoleId", DbType = "UniqueIdentifier", IsPrimaryKey = true)]
        public Guid RoleId { get; set; }
        [Column(Name = "UserId", DbType = "UniqueIdentifier", IsPrimaryKey = true)]
        public Guid UserId { get; set; }
    }
}
