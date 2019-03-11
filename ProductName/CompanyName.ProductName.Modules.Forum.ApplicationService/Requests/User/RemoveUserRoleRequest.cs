﻿using System;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public class RemoveUserRoleRequest : BaseRequest
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
