namespace CompanyName.ProductName.Modules.Forum.Website
{
    public class ViewDataErrorResourceStringRepository : IViewDataErrorLocalizationRepository
    {
        #region IViewDataErrorLocalizationRepository Members

        public string GetValue(string errorKey)
        {
            return ViewDataErrorResourceStrings.ResourceManager.GetString(errorKey);
        }

        #endregion
    }
}
