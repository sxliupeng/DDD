using System.ComponentModel.DataAnnotations;
using CompanyName.ProductName.Mvc.Common;

namespace CompanyName.ProductName.Modules.Forum.Website.ViewModels
{
    public class EditUserProfileViewModel : BaseViewModel
    {
        [DataType(DataType.Text)]
        [ResourceName("NickName")]
        [IsRequired]
        [MaxLength(32)]
        public string NickName { get; set; }
    }
}
