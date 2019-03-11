using System;
using System.Collections.Generic;
using CompanyName.ProductName.Common;
using CompanyName.ProductName.Modules.Forum.Repositories;

namespace CompanyName.ProductName.Modules.Forum.Models
{
    public class Role : AggregateRoot<Role, Guid>
    {
        public Role()
        {
            Key = Guid.NewGuid();
            AllowMask = 0;
            DenyMask = (long)-1;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public RoleType RoleType { get; set; }
        public long AllowMask { get; set; }
        public long DenyMask { get; set; }

        #region Public Methods

        public bool HasPermission(long mask)
        {
            bool bReturn = false;

            if ((DenyMask & mask) == mask)
            {
                bReturn = false;
            }
            if ((AllowMask & mask) == mask)
            {
                bReturn = true;
            }

            return bReturn;
        }
        public void SetPermission(long mask, AccessControlEntry accessControl)
        {
            switch (accessControl)
            {
                case AccessControlEntry.Allow:
                    AllowMask |= ((long)mask & (long)-1);
                    DenyMask &= ~((long)mask & (long)-1);
                    break;
                case AccessControlEntry.NotSet:
                    AllowMask &= ~((long)mask & (long)-1);
                    DenyMask &= ~((long)mask & (long)-1);
                    break;
                default:
                    AllowMask &= ~((long)mask & (long)-1);
                    DenyMask |= ((long)mask & (long)-1);
                    break;
            }
        }

        #endregion
    }
}
