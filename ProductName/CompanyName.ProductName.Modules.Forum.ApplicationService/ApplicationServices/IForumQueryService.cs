using System;
using System.Collections.Generic;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public interface IForumQueryService
    {
        IList<GroupData> GetGroups(string subject, bool? enabled);
        IPagedList<GroupData> GetPagedGroups(string subject, bool? enabled, int pageIndex, int pageSize);
        GroupData GetGroup(Guid id);

        IList<SectionData> GetSections(Guid groupId, string subject, bool? enabled);
        IPagedList<SectionData> GetPagedSections(Guid groupId, string subject, bool? enabled, int pageIndex, int pageSize);
        SectionData GetSection(Guid id);

        IPagedList<ThreadData> GetPagedThreads(Guid sectionId, Guid authorId, string subject, Guid replierId, ThreadDataStatus? status, ThreadDataReleaseStatus? releaseStatus, ThreadDataOrderType? orderType, int pageIndex, int pageSize);
        ThreadData GetThread(Guid id);

        IPagedList<PostData> GetPagedPosts(Guid threadId, int pageIndex, int pageSize);
        PostData GetPost(Guid id);

        IPagedList<RoleData> GetPagedRoles(int pageIndex, int pageSize);
        RoleData GetRole(Guid id);

        IPagedList<UserData> GetPagedUsers(string nickName, int totalMarks, string language, string siteTheme, UserStatus? userStatus, int pageIndex, int pageSize);
        UserData GetUser(Guid id);

        IPagedList<ExceptionLogData> GetPagedExceptionLogs(int pageIndex, int pageSize);
        ExceptionLogData GetExceptionLog(Guid id);
    }
}
