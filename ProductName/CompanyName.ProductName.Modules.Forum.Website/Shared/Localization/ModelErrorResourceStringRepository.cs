namespace CompanyName.ProductName.Modules.Forum.Website
{
    public class ModelErrorResourceStringRepository : IModelErrorLocalizationRepository
    {
        #region IModelErrorLocalizationRepository Members

        public string GetValue(string errorKey)
        {
            return ModelErrorResourceStrings.ResourceManager.GetString(errorKey);
        }

        #endregion
    }
}
