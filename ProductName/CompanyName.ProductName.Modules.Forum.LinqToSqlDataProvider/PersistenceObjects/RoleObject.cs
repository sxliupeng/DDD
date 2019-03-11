using System;
using System.Data.Linq.Mapping;

namespace CompanyName.ProductName.Modules.Forum.LinqToSqlDataProvider
{
    [Table(Name = "tb_Roles")]
    public class RoleObject
    {
        [Column(Name = "Id", DbType = "UniqueIdentifier", IsPrimaryKey = true)]
        public Guid Id { get; set; }
        [Column(Name = "Name", DbType = "NVarChar(256)", CanBeNull=false)]
        public string Name { get; set; }
        [Column(Name = "Description", DbType = "NVarChar(256)")]
        public string Description { get; set; }
        [Column(Name = "RoleType", DbType = "BigInt", CanBeNull = false)]
        public RoleType RoleType { get; set; }
        [Column(Name = "AllowMask", DbType = "BigInt")]
        public long AllowMask { get; set; }
        [Column(Name = "DenyMask", DbType = "BigInt")]
        public long DenyMask { get; set; }
    }
}
