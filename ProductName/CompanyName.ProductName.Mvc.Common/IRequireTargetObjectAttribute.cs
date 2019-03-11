using System.ComponentModel;

namespace CompanyName.ProductName.Mvc.Common
{
    public interface IRequireTargetObjectAttribute
    {
        object TargetObject { get; set; }
        PropertyDescriptor TargetProperty { get; set; }
    }
}
