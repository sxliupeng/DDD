using System;
using System.Linq;
using EventBasedDDD;
using CompanyName.ProductName.Modules.Forum.DomainEvents;

namespace CompanyName.ProductName.Modules.Forum.DomainObjects
{
    public class Thread : DomainObject<Guid>
    {
        #region Constructors

        public Thread(Guid sectionId, Guid authorId, int marks, DateTime createDate)
            : this(sectionId, authorId, createDate, marks, ThreadReleaseStatus.Open, 0, Guid.Empty, createDate)
        {
        }
        public Thread(Guid sectionId, Guid authorId, DateTime createDate, int marks, ThreadReleaseStatus releaseStatus, int totalPosts, Guid mostRecentReplierId, DateTime updateDate)
            : this(Guid.NewGuid(), sectionId, authorId, createDate, marks, releaseStatus, totalPosts, mostRecentReplierId, updateDate)
        {
        }
        public Thread(Guid id, Guid sectionId, Guid authorId, DateTime createDate, int marks, ThreadReleaseStatus releaseStatus, int totalPosts, Guid mostRecentReplierId, DateTime updateDate)
            : base(id)
        {
            this.SectionId = sectionId;
            this.AuthorId = authorId;
            this.CreateDate = createDate;
            this.UpdateDate = updateDate;
            this.TotalViews = 0;
            this.StickDate = new DateTime(1753, 1, 1);
            this.Status = ThreadStatus.Normal;
            this.ReleaseStatus = releaseStatus;
            this.TotalPosts = totalPosts;
            this.MostRecentReplierId = mostRecentReplierId;
        }

        #endregion

        #region Public Properties

        [TrackingProperty]
        public string Subject { get; set; }
        [TrackingProperty]
        public string Body { get; set; }
        [TrackingProperty]
        public int TotalViews { get; set; }
        [TrackingProperty]
        public int Marks { get; set; }
        [TrackingProperty]
        public DateTime StickDate { get; set; }
        [TrackingProperty]
        public ThreadStatus Status { get; set; }
        [TrackingProperty]
        public Guid SectionId { get; set; }

        public DateTime CreateDate { get; private set; }
        public Guid AuthorId { get; private set; }
        [TrackingProperty]
        public ThreadReleaseStatus ReleaseStatus { get; private set; }
        [TrackingProperty]
        public DateTime UpdateDate { get; private set; }
        [TrackingProperty]
        public int TotalPosts { get; private set; }
        [TrackingProperty]
        public Guid MostRecentReplierId { get; private set; }

        #endregion

        #region Event Handlers

        public void Handle(CloseThreadEvent evnt)
        {
            if (ReleaseStatus != ThreadReleaseStatus.Close)
            {
                if (evnt.PostAuthorMarks.Values.Sum() != Marks)
                {
                    throw new ThreadCloseMarksNotMatchException(ForumValidationError.CloseThreadTotalMarksNotMatch.GetName(), evnt.PostAuthorMarks.Values.Sum(), Marks);
                }
                ReleaseStatus = ThreadReleaseStatus.Close;
                EventProcesser.ProcessEvent(new ThreadClosedEvent { Thread = this });
            }
        }
        public void Handle(DomainObjectAddedEvent<Post> evnt)
        {
            this.TotalPosts++;
            this.MostRecentReplierId = evnt.DomainObject.AuthorId;
            this.UpdateDate = evnt.DomainObject.CreateDate;
        }
        public void Handle(DomainObjectRemovedEvent<Post> evnt)
        {
            this.TotalPosts--;
            if (evnt.DomainObject.CreateDate == this.UpdateDate)
            {
                var posts = Repository.Find<Post, FindPostsEvent>(evt => evt.ThreadId = this.Id);
                if (posts.Count > 0)
                {
                    posts.Sort((post1, post2) => DateTime.Compare(post1.CreateDate, post2.CreateDate));
                    var recentPost = posts[posts.Count - 1];
                    this.MostRecentReplierId = recentPost.AuthorId;
                    this.UpdateDate = recentPost.CreateDate;
                }
                else
                {
                    this.MostRecentReplierId = Guid.Empty;
                    this.UpdateDate = this.CreateDate;
                }
            }
        }

        #endregion
    }
}
