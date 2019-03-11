using System;

namespace CompanyName.ProductName.Modules.Forum
{
    public static class ValidationErrorExtentions
    {
        public static string GetName(this ForumValidationError validationError)
        {
            return string.Join("_", string.Format("{0}.{1}", validationError.GetType().FullName, Enum.GetName(validationError.GetType(), validationError)).Split('.'));
        }
    }

    public static class ForumEnumExtensions
    {
        public static bool HasValue(this UserStatus? source)
        {
            return source.HasValue;
        }

        public static bool HasValue(this RoleType? source)
        {
            return source.HasValue;
        }

        public static bool HasValue(this ThreadStatus? source)
        {
            return source.HasValue;
        }

        public static bool HasValue(this ThreadReleaseStatus? source)
        {
            return source.HasValue;
        }
    }
}
