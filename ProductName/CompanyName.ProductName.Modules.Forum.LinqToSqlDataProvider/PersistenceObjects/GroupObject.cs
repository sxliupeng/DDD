﻿using System;
using System.Data.Linq.Mapping;

namespace CompanyName.ProductName.Modules.Forum.LinqToSqlDataProvider
{
    [Table(Name = "tb_Groups")]
    public class GroupObject
    {
        [Column(Name = "Id", DbType = "UniqueIdentifier", IsPrimaryKey = true)]
        public Guid Id { get; set; }
        [Column(Name = "Subject", DbType = "NVarChar(128)", CanBeNull = false)]
        public string Subject { get; set; }
        [Column(Name = "Enabled", DbType = "Bit", CanBeNull = false)]
        public bool Enabled { get; set; }
    }
}
