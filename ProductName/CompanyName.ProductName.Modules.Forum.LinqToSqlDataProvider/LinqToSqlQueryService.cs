using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using CompanyName.ProductName.Modules.Forum.ApplicationServices;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.LinqToSqlDataProvider
{
    public class LinqToSqlQueryService : IForumQueryService
    {
        #region Private Variables

        private DataContext dataContext;

        #endregion

        #region Constructors

        public LinqToSqlQueryService(IDataContextProvider dataContextProvider)
        {
            dataContext = dataContextProvider.DataContext;
        }

        #endregion

        #region IForumQueryService Members

        public IList<GroupData> GetGroups(string subject, bool? enabled)
        {
            IQueryable<GroupObject> query = dataContext.GetTable<GroupObject>();

            if (subject.HasValue())
            {
                query = query.Where(group => group.Subject.Contains(subject));
            }
            if (enabled.HasValue())
            {
                query = query.Where(group => group.Enabled == enabled.Value);
            }

            return query.ToGroupDataList();
        }
        public IPagedList<GroupData> GetPagedGroups(string subject, bool? enabled, int pageIndex, int pageSize)
        {
            IQueryable<GroupObject> query = dataContext.GetTable<GroupObject>();

            if (subject.HasValue())
            {
                query = query.Where(group => group.Subject.Contains(subject));
            }
            if (enabled.HasValue())
            {
                query = query.Where(group => group.Enabled == enabled.Value);
            }

            return new PagedList<GroupData>(query.Take(pageSize).Skip(pageIndex * pageSize).ToGroupDataList(), query.Count(), pageIndex, pageSize);
        }
        public GroupData GetGroup(Guid id)
        {
            var groupObj = dataContext.GetTable<GroupObject>().Where(group => group.Id == id).FirstOrDefault();
            if (groupObj != null)
            {
                return groupObj.ToGroupData();
            }
            return null;
        }

        public IList<SectionData> GetSections(Guid groupId, string subject, bool? enabled)
        {
            IQueryable<SectionObject> sectionQuery = dataContext.GetTable<SectionObject>();

            if (groupId.HasValue())
            {
                sectionQuery = sectionQuery.Where(section => section.GroupId == groupId);
            }
            if (subject.HasValue())
            {
                sectionQuery = sectionQuery.Where(group => group.Subject.Contains(subject));
            }
            if (enabled.HasValue())
            {
                sectionQuery = sectionQuery.Where(group => group.Enabled == enabled.Value);
            }

            var query = from s in sectionQuery
                        join g in dataContext.GetTable<GroupObject>()
                        on s.GroupId equals g.Id
                        select new SectionWithGroupSubject { Section = s, GroupSubject = g.Subject };

            return query.ToSectionDataList();
        }
        public IPagedList<SectionData> GetPagedSections(Guid groupId, string subject, bool? enabled, int pageIndex, int pageSize)
        {
            IQueryable<SectionObject> sectionQuery = dataContext.GetTable<SectionObject>();

            if (groupId.HasValue())
            {
                sectionQuery = sectionQuery.Where(section => section.GroupId == groupId);
            }
            if (subject.HasValue())
            {
                sectionQuery = sectionQuery.Where(group => group.Subject.Contains(subject));
            }
            if (enabled.HasValue())
            {
                sectionQuery = sectionQuery.Where(group => group.Enabled == enabled.Value);
            }

            var query = from s in sectionQuery
                        join g in dataContext.GetTable<GroupObject>()
                        on s.GroupId equals g.Id
                        select new SectionWithGroupSubject { Section = s, GroupSubject = g.Subject };

            return new PagedList<SectionData>(query.Take(pageSize).Skip(pageIndex * pageSize).ToSectionDataList(), query.Count(), pageIndex, pageSize);
        }
        public SectionData GetSection(Guid id)
        {
            var query = from s in dataContext.GetTable<SectionObject>()
                        join g in dataContext.GetTable<GroupObject>()
                        on s.GroupId equals g.Id
                        where s.Id == id
                        select new SectionWithGroupSubject { Section = s, GroupSubject = g.Subject };

            var sectionAndGroupObject = query.FirstOrDefault();
            if (sectionAndGroupObject != null)
            {
                return sectionAndGroupObject.ToSectionData();
            }
            return null;
        }

        public IPagedList<ThreadData> GetPagedThreads(Guid sectionId, Guid authorId, string subject, Guid replierId, ThreadDataStatus? status, ThreadDataReleaseStatus? releaseStatus, ThreadDataOrderType? orderType, int pageIndex, int pageSize)
        {
            var threadQuery = from thread in dataContext.GetTable<ThreadObject>() select thread;
            var authorQuery = from author in dataContext.GetTable<UserObject>() select author;
            var replierQuery = from replier in dataContext.GetTable<UserObject>() select replier;

            if (replierId.HasValue())
            {
                threadQuery = from thread in threadQuery
                              join replier in replierQuery on thread.MostRecentReplierId equals replier.Id
                              where replier.Id == replierId
                              select thread;
            }

            if (sectionId.HasValue())
            {
                threadQuery = threadQuery.Where(thread => thread.SectionId == sectionId);
            }
            if (authorId.HasValue())
            {
                threadQuery = threadQuery.Where(thread => thread.AuthorId == authorId);
            }
            if (subject.HasValue())
            {
                threadQuery = threadQuery.Where(thread => thread.Subject.Contains(subject));
            }
            if (status.HasValue())
            {
                threadQuery = threadQuery.Where(thread => thread.Status == status.Value.ToThreadStatus());
            }
            if (releaseStatus.HasValue())
            {
                threadQuery = threadQuery.Where(thread => thread.ReleaseStatus == releaseStatus.Value.ToThreadReleaseStatus());
            }

            if (orderType.HasValue())
            {
                switch (orderType.Value)
                {
                    case ThreadDataOrderType.ViewCount:
                        threadQuery = threadQuery.OrderByDescending(thread => thread.TotalViews);
                        break;
                    case ThreadDataOrderType.UpdateDate:
                        threadQuery = threadQuery.OrderByDescending(thread => thread.UpdateDate);
                        break;
                    case ThreadDataOrderType.ReplyCount:
                        threadQuery = threadQuery.OrderByDescending(thread => thread.TotalPosts);
                        break;
                }
            }
            else
            {
                threadQuery = threadQuery.OrderByDescending(thread => thread.UpdateDate);
            }

            var query = from thread in threadQuery
                        //获取关联对象Author, 1:1，内连接
                        join author in authorQuery on thread.AuthorId equals author.Id
                        //获取关联对象MostRecentReplier, 1:1，左连接
                        join replier in replierQuery on thread.MostRecentReplierId equals replier.Id into mostRecentReplierQuery
                        from mostRecentReplier in mostRecentReplierQuery.DefaultIfEmpty()
                        //获取帖子及其关联的作者和最新回复人信息
                        select new ThreadWithAuthorAndReplyObject { Thread = thread, AuthorName = author.UserName, MostRecentReplierName = mostRecentReplier != null ? mostRecentReplier.UserName : null };

            return new PagedList<ThreadData>(query.Skip(pageIndex * pageSize).Take(pageSize).ToList().ToThreadDataList(), query.Count(), pageIndex, pageSize);
        }
        public ThreadData GetThread(Guid id)
        {
            var query = from thread in dataContext.GetTable<ThreadObject>()
                        //获取关联对象Author, 1:1，内连接
                        join author in dataContext.GetTable<UserObject>() on thread.AuthorId equals author.Id
                        //获取关联对象MostRecentReplier, 1:1，左连接
                        join replier in dataContext.GetTable<UserObject>() on thread.MostRecentReplierId equals replier.Id into mostRecentReplierQuery
                        from mostRecentReplier in mostRecentReplierQuery.DefaultIfEmpty()
                        //设置查询条件
                        where thread.Id == id
                        //获取帖子及其关联的作者和最新回复人信息
                        select new ThreadWithAuthorAndReplyObject { Thread = thread, AuthorName = author.UserName, MostRecentReplierName = mostRecentReplier != null ? mostRecentReplier.UserName : null };

            var threadWithAuthorAndReplyObject = query.FirstOrDefault();
            if (threadWithAuthorAndReplyObject != null)
            {
                return threadWithAuthorAndReplyObject.ToThreadData();
            }
            return null;
        }

        public IPagedList<PostData> GetPagedPosts(Guid threadId, int pageIndex, int pageSize)
        {
            var query = from post in dataContext.GetTable<PostObject>()
                        join user in dataContext.GetTable<UserObject>() on post.AuthorId equals user.Id
                        where post.ThreadId == threadId
                        select new PostWithAuthorNameObject { Post = post, AuthorName = user.UserName };

            return new PagedList<PostData>(query.Take(pageSize).Skip(pageIndex * pageSize).ToPostDataList(), query.Count(), pageIndex, pageSize);
        }
        public PostData GetPost(Guid id)
        {
            var query = from post in dataContext.GetTable<PostObject>()
                        join user in dataContext.GetTable<UserObject>() on post.AuthorId equals user.Id
                        where post.Id == id
                        select new PostWithAuthorNameObject { Post = post, AuthorName = user.UserName };

            var postWithAuthorNameObj = query.FirstOrDefault();
            if (postWithAuthorNameObj != null)
            {
                return postWithAuthorNameObj.ToPostData();
            }
            return null;
        }

        public IPagedList<RoleData> GetPagedRoles(int pageIndex, int pageSize)
        {
            var query = from role in dataContext.GetTable<RoleObject>() select role;

            return new PagedList<RoleData>(query.Take(pageSize).Skip(pageIndex * pageSize).ToRoleDataList(), query.Count(), pageIndex, pageSize);
        }
        public RoleData GetRole(Guid id)
        {
            var query = from role in dataContext.GetTable<RoleObject>() where role.Id == id select role;

            var roleObj = query.FirstOrDefault();
            if (roleObj != null)
            {
                return roleObj.ToRoleData();
            }
            return null;
        }

        public IPagedList<UserData> GetPagedUsers(string nickName, int totalMarks, string language, string siteTheme, UserStatus? userStatus, int pageIndex, int pageSize)
        {
            var query = from user in dataContext.GetTable<UserObject>() select user;

            if (nickName.HasValue())
            {
                query = query.Where(user => user.NickName == nickName);
            }
            if (totalMarks > 0)
            {
                query = query.Where(user => user.TotalMarks >= totalMarks);
            }
            if (language.HasValue())
            {
                query = query.Where(user => user.Language == language);
            }
            if (siteTheme.HasValue())
            {
                query = query.Where(user => user.SiteTheme == siteTheme);
            }
            if (userStatus.HasValue())
            {
                query = query.Where(user => user.UserStatus == userStatus.Value);
            }

            return new PagedList<UserData>(query.Take(pageSize).Skip(pageIndex * pageSize).ToUserDataList(), query.Count(), pageIndex, pageSize);
        }
        public UserData GetUser(Guid id)
        {
            var query = from user in dataContext.GetTable<UserObject>() where user.Id == id select user;

            var userObj = query.FirstOrDefault();
            if (userObj != null)
            {
                return userObj.ToUserData();
            }
            return null;
        }

        public IPagedList<ExceptionLogData> GetPagedExceptionLogs(int pageIndex, int pageSize)
        {
            var query = from exceptionLog in dataContext.GetTable<ExceptionLogObject>() select exceptionLog;
            return new PagedList<ExceptionLogData>(query.Take(pageSize).Skip(pageIndex * pageSize).ToExceptionLogDataList(), query.Count(), pageIndex, pageSize);
        }
        public ExceptionLogData GetExceptionLog(Guid id)
        {
            var query = from exceptionLog in dataContext.GetTable<ExceptionLogObject>() where exceptionLog.Id == id select exceptionLog;

            var exceptionLogObj = query.FirstOrDefault();
            if (exceptionLogObj != null)
            {
                return exceptionLogObj.ToExceptionLogData();
            }
            return null;
        }

        #endregion
    }
}
