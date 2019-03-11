using System.ComponentModel.DataAnnotations;
using CompanyName.ProductName.Mvc.Common;

namespace CompanyName.ProductName.Modules.Forum.Website.ViewModels
{
    [Equals("Password", "ConfirmPassword")]
    public class RegisterViewModel : BaseViewModel
    {
        [DataType(DataType.Text)]
        [ResourceName("MemberName")]
        [IsRequired]
        [MaxLength(32)]
        public string MemberName { get; set; }

        [DataType(DataType.Password)]
        [ResourceName("Password")]
        [IsRequired]
        [MaxLength(15)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [ResourceName("ConfirmPassword")]
        [IsRequired]
        [MaxLength(15)]
        public string ConfirmPassword { get; set; }
    }

    public class LogonViewModel : BaseViewModel
    {
        [DataType(DataType.Text)]
        [ResourceName("MemberName")]
        [IsRequired]
        [MaxLength(32)]
        public string MemberName { get; set; }

        [DataType(DataType.Password)]
        [ResourceName("Password")]
        [IsRequired]
        [MaxLength(15)]
        public string Password { get; set; }

        [ResourceName("RememberMe")]
        public bool RememberMe { get; set; }
    }

    [Equals("NewPassword", "ConfirmPassword")]
    public class ChangePasswordViewModel : BaseViewModel
    {
        [IsRequired]
        [DataType(DataType.Password)]
        [ResourceName("OldPassword")]
        [MaxLength(15)]
        public string OldPassword { get; set; }

        [IsRequired]
        [DataType(DataType.Password)]
        [ResourceName("NewPassword")]
        [MaxLength(15)]
        public string NewPassword { get; set; }

        [IsRequired]
        [DataType(DataType.Password)]
        [ResourceName("ConfirmNewPassword")]
        [MaxLength(15)]
        public string ConfirmPassword { get; set; }
    }
}
