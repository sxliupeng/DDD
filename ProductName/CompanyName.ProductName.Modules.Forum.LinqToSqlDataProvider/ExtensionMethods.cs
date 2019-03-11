using System.Collections.Generic;
using System.Linq;
using CompanyName.ProductName.Modules.Forum.ApplicationServices;
using CompanyName.ProductName.Modules.Forum.DomainObjects;

namespace CompanyName.ProductName.Modules.Forum.LinqToSqlDataProvider
{
    public static class DomainObjectPersistenceObjectMappingExtensions
    {
        #region Group

        public static Group ToGroup(this GroupObject groupObject)
        {
            return new Group(groupObject.Id, groupObject.Subject)
            {
                Enabled = groupObject.Enabled
            };
        }
        public static List<Group> ToGroupList(this IEnumerable<GroupObject> groupObjects)
        {
            List<Group> groupList = new List<Group>();
            groupObjects.ToList().ForEach(groupObject => groupList.Add(groupObject.ToGroup()));
            return groupList;
        }
        public static GroupObject ToGroupObject(this Group group)
        {
            return new GroupObject
            {
                Id = group.Id,
                Subject = group.Subject,
                Enabled = group.Enabled
            };
        }
        public static GroupObject UpdateAccordingWith(this GroupObject groupObject, Group group)
        {
            groupObject.Subject = group.Subject;
            groupObject.Enabled = group.Enabled;
            return groupObject;
        }

        #endregion

        #region Section

        public static Section ToSection(this SectionObject sectionObject)
        {
            return new Section(sectionObject.Id, sectionObject.GroupId, sectionObject.Subject)
            {
                Enabled = sectionObject.Enabled
            };
        }
        public static List<Section> ToSectionList(this IEnumerable<SectionObject> sectionObjects)
        {
            List<Section> sectionList = new List<Section>();
            sectionObjects.ToList().ForEach(sectionObject => sectionList.Add(sectionObject.ToSection()));
            return sectionList;
        }
        public static SectionObject ToSectionObject(this Section section)
        {
            return new SectionObject
            {
                Id = section.Id,
                Subject = section.Subject,
                Enabled = section.Enabled,
                GroupId = section.GroupId
            };
        }
        public static SectionObject UpdateAccordingWith(this SectionObject sectionObject, Section section)
        {
            sectionObject.Subject = section.Subject;
            sectionObject.Enabled = section.Enabled;
            return sectionObject;
        }

        #endregion

        #region Thread

        public static Thread ToThread(this ThreadObject threadObject)
        {
            return new Thread(
                threadObject.Id,
                threadObject.SectionId,
                threadObject.AuthorId,
                threadObject.CreateDate,
                threadObject.Marks,
                threadObject.ReleaseStatus,
                threadObject.TotalPosts,
                threadObject.MostRecentReplierId,
                threadObject.UpdateDate)
            {
                Subject = threadObject.Subject,
                Body = threadObject.Body,
                TotalViews = threadObject.TotalViews,
                StickDate = threadObject.StickDate,
                Status = threadObject.Status
            };
        }
        public static List<Thread> ToThreadList(this IEnumerable<ThreadObject> threadObjects)
        {
            List<Thread> threadList = new List<Thread>();
            threadObjects.ToList().ForEach(threadObject => threadList.Add(threadObject.ToThread()));
            return threadList;
        }
        public static ThreadObject ToThreadObject(this Thread thread)
        {
            return new ThreadObject
            {
                Id = thread.Id,
                Subject = thread.Subject,
                Body = thread.Body,
                TotalViews = thread.TotalViews,
                TotalPosts = thread.TotalPosts,
                StickDate = thread.StickDate,
                Status = thread.Status,
                SectionId = thread.SectionId,
                AuthorId = thread.AuthorId,
                CreateDate = thread.CreateDate,
                UpdateDate = thread.UpdateDate,
                Marks = thread.Marks,
                ReleaseStatus = thread.ReleaseStatus,
                MostRecentReplierId = thread.MostRecentReplierId
            };
        }
        public static ThreadObject UpdateAccordingWith(this ThreadObject threadObject, Thread thread)
        {
            threadObject.Subject = thread.Subject;
            threadObject.Body = thread.Body;
            threadObject.TotalViews = thread.TotalViews;
            threadObject.TotalPosts = thread.TotalPosts;
            threadObject.StickDate = thread.StickDate;
            threadObject.Status = thread.Status;
            threadObject.SectionId = thread.SectionId;
            threadObject.AuthorId = thread.AuthorId;
            threadObject.CreateDate = thread.CreateDate;
            threadObject.UpdateDate = thread.UpdateDate;
            threadObject.Marks = thread.Marks;
            threadObject.ReleaseStatus = thread.ReleaseStatus;
            threadObject.MostRecentReplierId = thread.MostRecentReplierId;
            return threadObject;
        }

        #endregion

        #region Post

        public static Post ToPost(this PostObject postObject)
        {
            return new Post(postObject.Id, postObject.ThreadId, postObject.AuthorId, postObject.CreateDate)
            {
                Body = postObject.Body
            };
        }
        public static List<Post> ToPostList(this IEnumerable<PostObject> postObjects)
        {
            List<Post> postList = new List<Post>();
            postObjects.ToList().ForEach(postObject => postList.Add(postObject.ToPost()));
            return postList;
        }
        public static PostObject ToPostObject(this Post post)
        {
            return new PostObject
            {
                Id = post.Id,
                ThreadId = post.ThreadId,
                AuthorId = post.AuthorId,
                CreateDate = post.CreateDate,
                Body = post.Body
            };
        }
        public static PostObject UpdateAccordingWith(this PostObject postObject, Post post)
        {
            postObject.Body = post.Body;
            return postObject;
        }

        #endregion

        #region User

        public static User ToUser(this UserObject userObject)
        {
            return new User(userObject.Id, userObject.UserName)
            {
                NickName = userObject.NickName,
                TotalMarks = userObject.TotalMarks,
                AvatarFileName = userObject.AvatarFileName,
                AvatarContent = userObject.AvatarContent,
                Language = userObject.Language,
                SiteTheme = userObject.SiteTheme,
                UserStatus = userObject.UserStatus
            };
        }
        public static List<User> ToUserList(this IEnumerable<UserObject> userObjects)
        {
            List<User> userList = new List<User>();
            userObjects.ToList().ForEach(userObject => userList.Add(userObject.ToUser()));
            return userList;
        }
        public static UserObject ToUserObject(this User user)
        {
            return new UserObject
            {
                Id = user.Id,
                UserName = user.UserName,
                NickName = user.NickName,
                TotalMarks = user.TotalMarks,
                AvatarFileName = user.AvatarFileName,
                AvatarContent = user.AvatarContent,
                Language = user.Language,
                SiteTheme = user.SiteTheme,
                UserStatus = user.UserStatus
            };
        }
        public static UserObject UpdateAccordingWith(this UserObject userObject, User user)
        {
            userObject.NickName = user.NickName;
            userObject.TotalMarks = user.TotalMarks;
            userObject.AvatarFileName = user.AvatarFileName;
            userObject.AvatarContent = user.AvatarContent;
            userObject.Language = user.Language;
            userObject.SiteTheme = user.SiteTheme;
            userObject.UserStatus = user.UserStatus;
            return userObject;
        }

        #endregion

        #region Role

        public static Role ToRole(this RoleObject roleObject)
        {
            return new Role(roleObject.Id)
            {
                 Name = roleObject.Name,
                 Description = roleObject.Description,
                 RoleType = roleObject.RoleType,
                 AllowMask = roleObject.AllowMask,
                 DenyMask = roleObject.DenyMask
            };
        }
        public static List<Role> ToRoleList(this IEnumerable<RoleObject> roleObjects)
        {
            List<Role> roleList = new List<Role>();
            roleObjects.ToList().ForEach(roleObject => roleList.Add(roleObject.ToRole()));
            return roleList;
        }
        public static RoleObject ToRoleObject(this Role role)
        {
            return new RoleObject
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description,
                RoleType = role.RoleType,
                AllowMask = role.AllowMask,
                DenyMask = role.DenyMask
            };
        }
        public static RoleObject UpdateAccordingWith(this RoleObject roleObject, Role role)
        {
            roleObject.Name = role.Name;
            roleObject.Description = role.Description;
            roleObject.RoleType = role.RoleType;
            roleObject.AllowMask = role.AllowMask;
            roleObject.DenyMask = role.DenyMask;
            return roleObject;
        }

        #endregion

        #region ExceptionLog

        public static ExceptionLog ToExceptionLog(this ExceptionLogObject exceptionLogObject)
        {
            return new ExceptionLog(exceptionLogObject.Id)
            {
                Message = exceptionLogObject.Message,
                ExceptionDetails = exceptionLogObject.ExceptionDetails,
                UserName = exceptionLogObject.UserName,
                IPAddress = exceptionLogObject.IPAddress,
                UserAgent = exceptionLogObject.UserAgent,
                HttpReferrer = exceptionLogObject.HttpReferrer,
                HttpVerb = exceptionLogObject.HttpVerb,
                PathAndQuery = exceptionLogObject.PathAndQuery,
                DateCreated = exceptionLogObject.DateCreated,
                DateLastOccurred = exceptionLogObject.DateLastOccurred,
                Frequency = exceptionLogObject.Frequency
            };
        }
        public static List<ExceptionLog> ToExceptionLogList(this IEnumerable<ExceptionLogObject> exceptionLogObjects)
        {
            List<ExceptionLog> exceptionLogList = new List<ExceptionLog>();
            exceptionLogObjects.ToList().ForEach(exceptionLogObject => exceptionLogList.Add(exceptionLogObject.ToExceptionLog()));
            return exceptionLogList;
        }
        public static ExceptionLogObject ToExceptionLogObject(this ExceptionLog exceptionLog)
        {
            return new ExceptionLogObject
            {
                Id = exceptionLog.Id,
                Message = exceptionLog.Message,
                ExceptionDetails = exceptionLog.ExceptionDetails,
                UserName = exceptionLog.UserName,
                IPAddress = exceptionLog.IPAddress,
                UserAgent = exceptionLog.UserAgent,
                HttpReferrer = exceptionLog.HttpReferrer,
                HttpVerb = exceptionLog.HttpVerb,
                PathAndQuery = exceptionLog.PathAndQuery,
                DateCreated = exceptionLog.DateCreated,
                DateLastOccurred = exceptionLog.DateLastOccurred,
                Frequency = exceptionLog.Frequency
            };
        }
        public static ExceptionLogObject UpdateAccordingWith(this ExceptionLogObject exceptionLogObject, ExceptionLog exceptionLog)
        {
            exceptionLogObject.Message = exceptionLog.Message;
            exceptionLogObject.ExceptionDetails = exceptionLog.ExceptionDetails;
            exceptionLogObject.UserName = exceptionLog.UserName;
            exceptionLogObject.IPAddress = exceptionLog.IPAddress;
            exceptionLogObject.UserAgent = exceptionLog.UserAgent;
            exceptionLogObject.HttpReferrer = exceptionLog.HttpReferrer;
            exceptionLogObject.HttpVerb = exceptionLog.HttpVerb;
            exceptionLogObject.PathAndQuery = exceptionLog.PathAndQuery;
            exceptionLogObject.DateCreated = exceptionLog.DateCreated;
            exceptionLogObject.DateLastOccurred = exceptionLog.DateLastOccurred;
            exceptionLogObject.Frequency = exceptionLog.Frequency;
            return exceptionLogObject;
        }

        #endregion
    }

    public static class DataTransferObjectPersistenceObjectMappingExtensions
    {
        #region Group

        public static List<GroupData> ToGroupDataList(this IEnumerable<GroupObject> groups)
        {
            List<GroupData> groupDataList = new List<GroupData>();
            groups.ToList().ForEach(groupObject => groupDataList.Add(groupObject.ToGroupData()));
            return groupDataList;
        }
        public static GroupData ToGroupData(this GroupObject groupObject)
        {
            return new GroupData
            {
                Id = groupObject.Id,
                Subject = groupObject.Subject,
                Enabled = groupObject.Enabled
            };
        }

        #endregion

        #region Section

        public static List<SectionData> ToSectionDataList(this IEnumerable<SectionWithGroupSubject> sectionAndGroupObjects)
        {
            List<SectionData> sectionDataList = new List<SectionData>();
            sectionAndGroupObjects.ToList().ForEach(sectionAndGroupObject => sectionDataList.Add(sectionAndGroupObject.ToSectionData()));
            return sectionDataList;
        }
        public static SectionData ToSectionData(this SectionWithGroupSubject sectionAndGroupObject)
        {
            return new SectionData
            {
                Id = sectionAndGroupObject.Section.Id,
                Subject = sectionAndGroupObject.Section.Subject,
                Enabled = sectionAndGroupObject.Section.Enabled,
                GroupId = sectionAndGroupObject.Section.GroupId,
                GroupSubject = sectionAndGroupObject.GroupSubject
            };
        }

        #endregion

        #region Thread

        public static List<ThreadData> ToThreadDataList(this IEnumerable<ThreadWithAuthorAndReplyObject> threadWithAuthorAndReplyObjects)
        {
            List<ThreadData> threadDataList = new List<ThreadData>();
            threadWithAuthorAndReplyObjects.ToList().ForEach(threadWithAuthorAndReplyObject => threadDataList.Add(threadWithAuthorAndReplyObject.ToThreadData()));
            return threadDataList;
        }
        public static ThreadData ToThreadData(this ThreadWithAuthorAndReplyObject threadWithAuthorAndReplyObject)
        {
            var threadObject = threadWithAuthorAndReplyObject.Thread;
            return new ThreadData
            {
                Id = threadObject.Id,
                Subject = threadObject.Subject,
                Body = threadObject.Body,
                TotalViews = threadObject.TotalViews,
                TotalPosts = threadObject.TotalPosts,
                StickDate = threadObject.StickDate,
                Status = threadObject.Status.ToThreadDataStatus(),
                SectionId = threadObject.SectionId,
                AuthorId = threadObject.AuthorId,
                AuthorName = threadWithAuthorAndReplyObject.AuthorName,
                MostRecentReplierId = threadObject.MostRecentReplierId,
                MostRecentReplierName = threadWithAuthorAndReplyObject.MostRecentReplierName,
                CreateDate = threadObject.CreateDate,
                UpdateDate = threadObject.UpdateDate,
                Marks = threadObject.Marks,
                ReleaseStatus = threadObject.ReleaseStatus.ToThreadDataReleaseStatus()
            };
        }

        #endregion

        #region Post

        public static List<PostData> ToPostDataList(this IEnumerable<PostWithAuthorNameObject> postWithAuthorNameObjects)
        {
            List<PostData> postDataList = new List<PostData>();
            postWithAuthorNameObjects.ToList().ForEach(postWithAuthorNameObject => postDataList.Add(postWithAuthorNameObject.ToPostData()));
            return postDataList;
        }
        public static PostData ToPostData(this PostWithAuthorNameObject postWithAuthorNameObject)
        {
            var postObj = postWithAuthorNameObject.Post;
            return new PostData
            {
                Id = postObj.Id,
                Body = postObj.Body,
                AuthorId = postObj.AuthorId,
                CreateDate = postObj.CreateDate,
                ThreadId = postObj.ThreadId,
                AuthorName = postWithAuthorNameObject.AuthorName
            };
        }

        #endregion

        #region User

        public static List<UserData> ToUserDataList(this IEnumerable<UserObject> userObjects)
        {
            List<UserData> userDataList = new List<UserData>();
            userObjects.ToList().ForEach(userObject => userDataList.Add(userObject.ToUserData()));
            return userDataList;
        }
        public static UserData ToUserData(this UserObject userObject)
        {
            return new UserData
            {
                Id = userObject.Id,
                UserName = userObject.UserName,
                NickName = userObject.NickName,
                TotalMarks = userObject.TotalMarks,
                AvatarFileName = userObject.AvatarFileName,
                AvatarContent = userObject.AvatarContent,
                Language = userObject.Language,
                SiteTheme = userObject.SiteTheme,
                UserStatus = userObject.UserStatus.ToUserDataType()
            };
        }

        #endregion

        #region Role

        public static List<RoleData> ToRoleDataList(this IEnumerable<RoleObject> roleObjects)
        {
            List<RoleData> roleDataList = new List<RoleData>();
            roleObjects.ToList().ForEach(roleObject => roleDataList.Add(roleObject.ToRoleData()));
            return roleDataList;
        }
        public static RoleData ToRoleData(this RoleObject roleObject)
        {
            return new RoleData
            {
                Id = roleObject.Id,
                Name = roleObject.Name,
                Description = roleObject.Description,
                RoleType = roleObject.RoleType.ToRoleDataType(),
                AllowMask = roleObject.AllowMask,
                DenyMask = roleObject.DenyMask
            };
        }

        #endregion

        #region ExceptionLog

        public static List<ExceptionLogData> ToExceptionLogDataList(this IEnumerable<ExceptionLogObject> exceptionLogObjects)
        {
            List<ExceptionLogData> exceptionLogDataList = new List<ExceptionLogData>();
            exceptionLogObjects.ToList().ForEach(exceptionLogObject => exceptionLogDataList.Add(exceptionLogObject.ToExceptionLogData()));
            return exceptionLogDataList;
        }
        public static ExceptionLogData ToExceptionLogData(this ExceptionLogObject exceptionLogObject)
        {
            return new ExceptionLogData
            {
                Id = exceptionLogObject.Id,
                Message = exceptionLogObject.Message,
                ExceptionDetails = exceptionLogObject.ExceptionDetails,
                UserName = exceptionLogObject.UserName,
                IPAddress = exceptionLogObject.IPAddress,
                UserAgent = exceptionLogObject.UserAgent,
                HttpReferrer = exceptionLogObject.HttpReferrer,
                HttpVerb = exceptionLogObject.HttpVerb,
                PathAndQuery = exceptionLogObject.PathAndQuery,
                DateCreated = exceptionLogObject.DateCreated,
                DateLastOccurred = exceptionLogObject.DateLastOccurred,
                Frequency = exceptionLogObject.Frequency
            };
        }

        #endregion
    }
}
