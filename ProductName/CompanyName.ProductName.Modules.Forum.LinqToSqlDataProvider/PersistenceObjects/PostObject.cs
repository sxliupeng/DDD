using System;
using System.Data.Linq.Mapping;

namespace CompanyName.ProductName.Modules.Forum.LinqToSqlDataProvider
{
    [Table(Name = "tb_Posts")]
    public class PostObject
    {
        [Column(Name = "Id", DbType = "UniqueIdentifier", IsPrimaryKey = true)]
        public Guid Id { get; set; }
        [Column(Name = "Body", DbType = "NVarChar(MAX)")]
        public string Body { get; set; }
        [Column(Name = "CreateDate", DbType = "DateTime", CanBeNull = false)]
        public DateTime CreateDate { get; set; }
        [Column(Name = "ThreadId", DbType = "UniqueIdentifier", CanBeNull = false)]
        public Guid ThreadId { get; set; }
        [Column(Name = "AuthorId", DbType = "UniqueIdentifier", CanBeNull = false)]
        public Guid AuthorId { get; set; }
    }
}
