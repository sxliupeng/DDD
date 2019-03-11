using System;
using System.Collections.Generic;
using CompanyName.ProductName.Common;

namespace CompanyName.ProductName.Modules.Forum.Models
{
    public class Thread : AggregateRoot<Thread, Guid>
    {
        public Thread()
        {
            Key = Guid.NewGuid();
            Posts = new List<Post>();
        }

        public string Subject { get; set; }
        public string Body { get; set; }
        public Guid AuthorId { get; set; }
        public Guid SectionId { get; set; }
        public int TotalPosts { get; set; }
        public int TotalViews { get; set; }
        public Guid MostRecentReplierId { get; set; }
        public int ThreadMarks { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime StickDate { get; set; }
        public ThreadStatus ThreadStatus { get; set; }
        public ThreadReleaseStatus ThreadReleaseStatus { get; set; }

        public User Author { get; set; }
        public User MostRecentReplier { get; set; }
        public Section Section { get; set; }
        public List<Post> Posts { get; set; }

        public void AddPost(Post post)
        {
            if (Posts.Find(p => p.Key == post.Key) != null)
            {
                throw new BusinessValidationException().AddErrorKey(ValidationError.PostAlreadyExist.GetName());
            }

            Posts.Add(post);
            TotalPosts++;
            MostRecentReplierId = post.AuthorId;
            UpdateDate = post.CreateDate;
        }
        public void ClearPostContent(Guid postId)
        {
            var post = Posts.Find(p => p.Key == postId);
            if (post == null)
            {
                throw new BusinessValidationException().AddErrorKey(ValidationError.PostNotExist.GetName());
            }

            post.Body = "该回复已被管理员删除！";
        }
    }
}
