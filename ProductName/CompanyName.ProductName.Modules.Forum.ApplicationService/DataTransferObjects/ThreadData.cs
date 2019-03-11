using System;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public class ThreadData
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
        public Guid SectionId { get; set; }
        public int TotalPosts { get; set; }
        public int TotalViews { get; set; }
        public Guid MostRecentReplierId { get; set; }
        public string MostRecentReplierName { get; set; }
        public int Marks { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime StickDate { get; set; }
        public ThreadDataStatus Status { get; set; }
        public ThreadDataReleaseStatus ReleaseStatus { get; set; }
    }

    public enum ThreadDataStatus
    {
        Normal = 1,        //一般帖子
        Recommended = 2,   //推荐帖子
        Stick = 3,         //置顶帖子
    }

    public enum ThreadDataReleaseStatus
    {
        Open = 1,         //未解决帖子
        Close = 2,        //已解决帖子
        Deleted = 3,      //已删除帖子
    }

    public enum ThreadDataOrderType
    {
        UpdateDate = 0,       //更新时间
        ViewCount = 1,        //点击次数
        ReplyCount = 2,       //回复次数
    }
}
