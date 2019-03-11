using System;
using System.Data.Linq.Mapping;

namespace CompanyName.ProductName.Modules.Forum.LinqToSqlDataProvider
{
    [Table(Name="tb_ExceptionLogs")]
    public class ExceptionLogObject
    {
        [Column(Name = "Id", DbType = "UniqueIdentifier", IsPrimaryKey=true)]
        public Guid Id { get; set; }
        [Column(Name = "Message", DbType = "NVarChar(512)", CanBeNull=false)]
        public string Message { get; set; }
        [Column(Name = "ExceptionDetails", DbType = "NVarChar(MAX)", CanBeNull = false)]
        public string ExceptionDetails { get; set; }
        [Column(Name = "UserName", DbType = "NVarChar(64)")]
        public string UserName { get; set; }
        [Column(Name = "IPAddress", DbType = "NVarChar(50)")]
        public string IPAddress { get; set; }
        [Column(Name = "UserAgent", DbType = "NVarChar(256)")]
        public string UserAgent { get; set; }
        [Column(Name = "HttpReferrer", DbType = "NVarChar(256)")]
        public string HttpReferrer { get; set; }
        [Column(Name = "HttpVerb", DbType = "NVarChar(50)")]
        public string HttpVerb { get; set; }
        [Column(Name = "PathAndQuery", DbType = "NVarChar(512)")]
        public string PathAndQuery { get; set; }
        [Column(Name = "DateCreated", DbType = "DateTime", CanBeNull = false)]
        public DateTime DateCreated { get; set; }
        [Column(Name = "DateLastOccurred", DbType = "DateTime", CanBeNull = false)]
        public DateTime DateLastOccurred { get; set; }
        [Column(Name = "Frequency", DbType = "Int", CanBeNull = false)]
        public int Frequency { get; set; }
    }
}
