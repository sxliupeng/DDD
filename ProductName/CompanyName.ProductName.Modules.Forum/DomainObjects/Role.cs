using System;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.DomainObjects
{
    public class Role : DomainObject<Guid>
    {
        #region Constructors

        public Role()
            : this(Guid.NewGuid())
        {
        }
        public Role(Guid id)
            : base(id)
        {
            AllowMask = 0;
            DenyMask = (long)-1;
        }

        #endregion

        #region Public Properties

        [TrackingProperty]
        public string Name { get; set; }
        [TrackingProperty]
        public string Description { get; set; }
        [TrackingProperty]
        public RoleType RoleType { get; set; }
        [TrackingProperty]
        public long AllowMask { get; set; }
        [TrackingProperty]
        public long DenyMask { get; set; }

        #endregion

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
