using System;
using System.ComponentModel;

namespace CompanyName.ProductName.Mvc.Common
{
    public class BaseViewData
    {
        public BaseViewData()
        {
            foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(this))
            {
                ProcessPropertyValidationAttributes(propertyDescriptor);
            }
        }

        private void ProcessPropertyValidationAttributes(PropertyDescriptor propertyDescriptor)
        {
            foreach (Attribute attribute in propertyDescriptor.Attributes)
            {
                if (attribute is IRequireDisplayNameAttribute)
                {
                    var requireDisplayNameAttribute = attribute as IRequireDisplayNameAttribute;
                    requireDisplayNameAttribute.PropertyDisplayName = GetPropertyDisplayName(propertyDescriptor);
                }
                if (attribute is IRequireTargetObjectAttribute)
                {
                    var requireTargetObjectAttribute = attribute as IRequireTargetObjectAttribute;
                    requireTargetObjectAttribute.TargetObject = this;
                    requireTargetObjectAttribute.TargetProperty = propertyDescriptor;
                }
            }
        }

        private string GetPropertyDisplayName(PropertyDescriptor propertyDescriptor)
        {
            DisplayNameAttribute displayNameAttribute = null;
            foreach (Attribute attribute in propertyDescriptor.Attributes)
            {
                displayNameAttribute = attribute as DisplayNameAttribute;
                if (displayNameAttribute != null)
                {
                    return displayNameAttribute.DisplayName;
                }
            }
            return null;
        }
    }
}
