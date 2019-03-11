using System;
using System.Data.Linq.Mapping;

namespace CompanyName.ProductName.Modules.Forum.LinqToSqlDataProvider
{
    [Table(Name = "tb_Threads")]
    public class ThreadObject
    {
        [Column(Name = "Id", DbType = "UniqueIdentifier", IsPrimaryKey = true)]
        public Guid Id { get; set; }
        [Column(Name = "Subject", DbType = "NVarChar(256)", CanBeNull = false)]
        public string Subject { get; set; }
        [Column(Name = "Body", DbType = "NVarChar(MAX)", CanBeNull = false)]
        public string Body { get; set; }
        [Column(Name = "CreateDate", DbType = "DateTime", CanBeNull = false)]
        public DateTime CreateDate { get; set; }
        [Column(Name = "UpdateDate", DbType = "DateTime", CanBeNull = false)]
        public DateTime UpdateDate { get; set; }
        [Column(Name = "StickDate", DbType = "DateTime", CanBeNull = false)]
        public DateTime StickDate { get; set; }
        [Column(Name = "TotalPosts", DbType = "Int", CanBeNull = false)]
        public int TotalPosts { get; set; }
        [Column(Name = "TotalViews", DbType = "Int", CanBeNull = false)]
        public int TotalViews { get; set; }
        [Column(Name = "Status", DbType = "Int", CanBeNull = false)]
        public ThreadStatus Status { get; set; }
        [Column(Name = "ReleaseStatus", DbType = "Int", CanBeNull = false)]
        public ThreadReleaseStatus ReleaseStatus { get; set; }
        [Column(Name = "Marks", DbType = "Int", CanBeNull = false)]
        public int Marks { get; set; }
        [Column(Name = "SectionId", DbType = "UniqueIdentifier", CanBeNull = false)]
        public Guid SectionId { get; set; }
        [Column(Name = "AuthorId", DbType = "UniqueIdentifier", CanBeNull = false)]
        public Guid AuthorId { get; set; }
        [Column(Name = "MostRecentReplierId", DbType = "UniqueIdentifier", CanBeNull = false)]
        public Guid MostRecentReplierId { get; set; }
    }
}
