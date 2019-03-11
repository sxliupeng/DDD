namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public static class MiscExtensions
    {
        #region ThreadStatus and ThreadReleaseStatus Mapping

        public static ThreadDataStatus ToThreadDataStatus(this ThreadStatus source)
        {
            switch (source)
            {
                case ThreadStatus.Normal:
                    return ThreadDataStatus.Normal;
                case ThreadStatus.Recommended:
                    return ThreadDataStatus.Recommended;
                case ThreadStatus.Stick:
                    return ThreadDataStatus.Stick;
                default:
                    return ThreadDataStatus.Normal;
            }
        }
        public static ThreadDataReleaseStatus ToThreadDataReleaseStatus(this ThreadReleaseStatus source)
        {
            switch (source)
            {
                case ThreadReleaseStatus.Open:
                    return ThreadDataReleaseStatus.Open;
                case ThreadReleaseStatus.Close:
                    return ThreadDataReleaseStatus.Close;
                case ThreadReleaseStatus.Deleted:
                    return ThreadDataReleaseStatus.Deleted;
                default:
                    return ThreadDataReleaseStatus.Open;
            }
        }
        public static RoleDataType ToRoleDataType(this RoleType source)
        {
            switch (source)
            {
                case RoleType.AllowDelete:
                    return RoleDataType.AllowDelete;
                case RoleType.AllowEditPermission:
                    return RoleDataType.AllowEditPermission;
                case RoleType.AllowVisible:
                    return RoleDataType.AllowVisible;
                default:
                    return RoleDataType.AllowDelete;
            }
        }
        public static UserDataStatus ToUserDataType(this UserStatus source)
        {
            switch (source)
            {
                case UserStatus.Normal:
                    return UserDataStatus.Normal;
                case UserStatus.Locked:
                    return UserDataStatus.Locked;
                default:
                    return UserDataStatus.Normal;
            }
        }
        public static ThreadStatus ToThreadStatus(this ThreadDataStatus source)
        {
            switch (source)
            {
                case ThreadDataStatus.Normal:
                    return ThreadStatus.Normal;
                case ThreadDataStatus.Recommended:
                    return ThreadStatus.Recommended;
                case ThreadDataStatus.Stick:
                    return ThreadStatus.Stick;
                default:
                    return ThreadStatus.Normal;
            }
        }
        public static ThreadReleaseStatus ToThreadReleaseStatus(this ThreadDataReleaseStatus source)
        {
            switch (source)
            {
                case ThreadDataReleaseStatus.Open:
                    return ThreadReleaseStatus.Open;
                case ThreadDataReleaseStatus.Close:
                    return ThreadReleaseStatus.Close;
                case ThreadDataReleaseStatus.Deleted:
                    return ThreadReleaseStatus.Deleted;
                default:
                    return ThreadReleaseStatus.Open;
            }
        }
        public static RoleType ToRoleType(this RoleDataType source)
        {
            switch (source)
            {
                case RoleDataType.AllowDelete:
                    return RoleType.AllowDelete;
                case RoleDataType.AllowEditPermission:
                    return RoleType.AllowEditPermission;
                case RoleDataType.AllowVisible:
                    return RoleType.AllowVisible;
                default:
                    return RoleType.AllowDelete;
            }
        }
        public static UserStatus ToUserType(this UserDataStatus source)
        {
            switch (source)
            {
                case UserDataStatus.Normal:
                    return UserStatus.Normal;
                case UserDataStatus.Locked:
                    return UserStatus.Locked;
                default:
                    return UserStatus.Normal;
            }
        }

        #endregion

        #region HasValue Functions

        public static bool HasValue(this ThreadDataStatus? source)
        {
            return source.HasValue;
        }
        public static bool HasValue(this ThreadDataReleaseStatus? source)
        {
            return source.HasValue;
        }
        public static bool HasValue(this ThreadDataOrderType? source)
        {
            return source.HasValue;
        }

        #endregion
    }
}
