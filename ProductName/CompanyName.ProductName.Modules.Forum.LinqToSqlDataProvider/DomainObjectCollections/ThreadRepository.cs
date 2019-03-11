using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using CompanyName.ProductName.Common;
using CompanyName.ProductName.Modules.Forum.Models;
using CompanyName.ProductName.Modules.Forum.Repositories;

namespace CompanyName.ProductName.Modules.Forum.LinqToSqlDataProvider
{
    public class ThreadRepository : IThreadRepository
    {
        private DataContext dataContext;

        public ThreadRepository(IUnitOfWorkManager unitOfWorkManager)
        {
            this.dataContext = unitOfWorkManager as DataContext;
        }

        #region IThreadRepository Members

        public void Add(Thread thread)
        {
            dataContext.GetTable<Thread>().InsertOnSubmit(thread);
        }

        public Thread GetThread(Guid threadId)
        {
            Thread thread = null;

            var userQuery = dataContext.GetTable<User>();
            var postQuery = dataContext.GetTable<Post>();
            var threadQuery = dataContext.GetTable<Thread>();
            var sectionQuery = dataContext.GetTable<Section>();

            var query = from t in threadQuery
                        //获取关联对象Author, 1:1，内连接
                        join author in userQuery on t.AuthorId equals author.Id
                        //获取关联对象Section, 1:1，内连接
                        join section in sectionQuery on t.SectionId equals section.Id
                        //获取关联对象MostRecentReplier, 1:1，左连接
                        join replier in userQuery on t.MostRecentReplierId equals replier.Id into mostRecentReplierQuery
                        from mostRecentReplier in mostRecentReplierQuery.DefaultIfEmpty()
                        //获取关联对象Posts, 1:N，左连接
                        join p in (from post in postQuery join author in userQuery on post.AuthorId equals author.Id orderby post.CreateDate ascending select new { Post = post, Author = author }) on t.Id equals p.Post.ThreadId into threadPostQuery
                        let posts = threadPostQuery.DefaultIfEmpty()
                        //设置查询条件
                        where t.Id == threadId
                        //将帖子本身和所有关联对象都放入匿名对象中
                        select new { Thread = t, Author = author, MostRecentReplier = mostRecentReplier, Section = section, Posts = posts };

            //执行查询
            var queryResult = query.FirstOrDefault();  //这里使用FirstOrDefault，而不是SingleOrDefault，因为其效率更高。

            if (queryResult != null && queryResult.Thread != null)
            {
                //以下代码从查询出来的匿名对象中获取帖子对象及其所有的关联对象

                thread = queryResult.Thread;
                thread.Author = queryResult.Author;
                thread.MostRecentReplier = queryResult.MostRecentReplier;
                thread.Section = queryResult.Section;

                thread.Posts = new List<Post>();
                int basePostFloor = 1;
                foreach (var postAndAuthor in queryResult.Posts)
                {
                    if (postAndAuthor != null)
                    {
                        postAndAuthor.Post.Thread = thread;
                        postAndAuthor.Post.Author = postAndAuthor.Author;
                        postAndAuthor.Post.PostFloor = basePostFloor;
                        thread.Posts.Add(postAndAuthor.Post);
                        basePostFloor++;
                    }
                }
            }

            //最后将帖子返回
            return thread;
        }

        public Post GetPost(Guid postId)
        {
            return dataContext.GetTable<Post>().Where(post => post.Id == postId).FirstOrDefault();
        }

        public void AddPost(Post post)
        {
            dataContext.GetTable<Post>().InsertOnSubmit(post);
        }

        #endregion

        #region IThreadRepository Members

        #endregion
    }
}
