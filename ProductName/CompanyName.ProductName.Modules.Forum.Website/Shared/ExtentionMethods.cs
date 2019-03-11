using System.Collections.Generic;
using System.Web.Mvc;
using CompanyName.ProductName.Modules.Forum.ApplicationServices;
using CompanyName.ProductName.Modules.Forum.Website.ViewData;
using CompanyName.ProductName.Mvc.Common;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.Website.Controllers
{
    public static class ExtentionMethods
    {
        #region Model Error

        public static void MergeError(this ModelStateDictionary modelState, ErrorState errorState)
        {
            if (errorState.ErrorItems.Count > 0)
            {
                var localizationRepository = InstanceLocator.Current.GetInstance<IModelErrorLocalizationRepository>();
                foreach (var errorItem in errorState.ErrorItems)
                {
                    modelState.AddModelError(string.Empty, string.Format(localizationRepository.GetValue(errorItem.Key), errorItem.Parameters.ToArray()));
                }
            }
            else if (!string.IsNullOrEmpty(errorState.ExceptionMessage))
            {
                modelState.AddModelError(string.Empty, errorState.ExceptionMessage);
            }
        }

        #endregion

        #region Group

        public static GroupViewData ToViewData(this GroupData groupData)
        {
            return new GroupViewData()
            {
                Id = groupData.Id,
                Subject = groupData.Subject,
                Enabled = groupData.Enabled
            };
        }
        public static IPagedViewDataList<GroupViewData> ToViewData(this IPagedList<GroupData> pagedGroupData)
        {
            IList<GroupViewData> modelList = new List<GroupViewData>();
            pagedGroupData.ForEach<GroupData>(groupData => modelList.Add(groupData.ToViewData()));
            return new PagedViewDataList<GroupViewData>(modelList, pagedGroupData.TotalCount, pagedGroupData.PageIndex, pagedGroupData.PageSize);
        }

        #endregion

        #region Section

        public static SectionViewData ToViewData(this SectionData sectionData)
        {
            return new SectionViewData()
            {
                Id = sectionData.Id,
                Subject = sectionData.Subject,
                Enabled = sectionData.Enabled,
                GroupId = sectionData.GroupId,
                GroupSubject = sectionData.GroupSubject
            };
        }
        public static EditSectionViewData ToEditViewData(this SectionData sectionData)
        {
            return new EditSectionViewData()
            {
                Id = sectionData.Id,
                Subject = sectionData.Subject,
                Enabled = sectionData.Enabled,
                GroupId = sectionData.GroupId
            };
        }
        public static IPagedViewDataList<SectionViewData> ToViewData(this IPagedList<SectionData> pagedSectionData)
        {
            IList<SectionViewData> modelList = new List<SectionViewData>();
            pagedSectionData.ForEach<SectionData>(sectionData => modelList.Add(sectionData.ToViewData()));
            return new PagedViewDataList<SectionViewData>(modelList, pagedSectionData.TotalCount, pagedSectionData.PageIndex, pagedSectionData.PageSize);
        }

        #endregion
    }
}
