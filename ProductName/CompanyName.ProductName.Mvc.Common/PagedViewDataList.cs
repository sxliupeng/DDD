using System.Collections.Generic;

namespace CompanyName.ProductName.Mvc.Common
{
    public interface IPagedViewDataList<TViewData> : IList<TViewData>
    {
        int TotalCount { get; set; }
        int PageIndex { get; set; }
        int PageSize { get; set; }
        int NumberOfPages { get; }
    }

    public class PagedViewDataList<TViewData> : List<TViewData>, IPagedViewDataList<TViewData>
    {
        public PagedViewDataList(IEnumerable<TViewData> pageData, int totalCount, int pageIndex, int pageSize)
        {
            this.TotalCount = totalCount;
            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            this.AddRange(pageData);
        }

        public int TotalCount
        {
            get;
            set;
        }

        public int PageIndex
        {
            get;
            set;
        }

        public int PageSize
        {
            get;
            set;
        }

        public int NumberOfPages
        {
            get
            {
                int pageCount = TotalCount / PageSize;
                return TotalCount % PageSize == 0 ? pageCount : pageCount + 1;
            }
        }
    }
}
