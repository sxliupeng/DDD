using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EventBasedDDD;
using CompanyName.ProductName.Mvc.Common;

namespace CompanyName.ProductName.Modules.Forum.Website
{
    public class ResourceNameAttribute : DisplayNameAttribute
    {
        private readonly string resourceName;
        public ResourceNameAttribute(string resourceName)
            : base()
        {
            this.resourceName = resourceName;
        }

        public override string DisplayName
        {
            get
            {
                return InstanceLocator.Current.GetInstance<IViewDataErrorLocalizationRepository>().GetValue(this.resourceName);
            }
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class IsRequiredAttribute : RequiredAttribute, IRequireDisplayNameAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return string.Format(InstanceLocator.Current.GetInstance<IViewDataErrorLocalizationRepository>().GetValue("PropertyValueNullException"), PropertyDisplayName);
        }

        #region IRequireDisplayNameAttribute Members

        public string PropertyDisplayName { get; set; }

        #endregion
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class MaxLengthAttribute : StringLengthAttribute, IRequireDisplayNameAttribute
    {
        public MaxLengthAttribute(int maxLength) : base(maxLength)
        {
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(InstanceLocator.Current.GetInstance<IViewDataErrorLocalizationRepository>().GetValue("PropertyValueExceedMaxLength"), PropertyDisplayName, MaximumLength);
        }

        #region IRequireDisplayNameAttribute Members

        public string PropertyDisplayName { get; set; }

        #endregion
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class EqualsAttribute : ValidationAttribute
    {
        private readonly object typeId = new object();
        private readonly string firstPropertyName;
        private readonly string secondPropertyName;
        private string firstPropertyDisplayTitle;
        private string secondPropertyDisplayTitle;

        public EqualsAttribute(string firstPropertyName, string secondPropertyName)
            : base()
        {
            this.firstPropertyName = firstPropertyName;
            this.secondPropertyName = secondPropertyName;
            this.firstPropertyDisplayTitle = firstPropertyName;
            this.secondPropertyDisplayTitle = secondPropertyName;
        }

        public override object TypeId
        {
            get
            {
                return typeId;
            }
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(InstanceLocator.Current.GetInstance<IViewDataErrorLocalizationRepository>().GetValue("PropertyValueNotMatch"), firstPropertyDisplayTitle, secondPropertyDisplayTitle);
        }

        public override bool IsValid(object value)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value);
            var firstPropertyDescriptor = properties.Find(firstPropertyName, true);
            var secondPropertyDescriptor = properties.Find(secondPropertyName, true);

            bool isValid = Equals(firstPropertyDescriptor.GetValue(value), secondPropertyDescriptor.GetValue(value));

            if (!isValid)
            {
                firstPropertyDisplayTitle = GetPropertyDisplayName(firstPropertyDescriptor);
                secondPropertyDisplayTitle = GetPropertyDisplayName(secondPropertyDescriptor);
            }

            return isValid;
        }

        private string GetPropertyDisplayName(PropertyDescriptor propertyDescriptor)
        {
            ResourceNameAttribute displayNameAttribute = null;
            foreach (Attribute attribute in propertyDescriptor.Attributes)
            {
                displayNameAttribute = attribute as ResourceNameAttribute;
                if (displayNameAttribute != null)
                {
                    return displayNameAttribute.DisplayName;
                }
            }
            return null;
        }
    }
}
