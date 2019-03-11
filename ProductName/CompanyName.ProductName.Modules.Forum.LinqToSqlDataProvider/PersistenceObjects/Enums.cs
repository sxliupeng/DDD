using CompanyName.ProductName.Common;
namespace CompanyName.ProductName.Modules.Forum.Models
{
    public enum UserStatus
    {
        Normal = 1,  //正常用户
        Locked = 2,  //冻结用户
    }
    public enum RoleType
    {
        AllowVisible = 0x0000000000000001,               //在用户角色管理中允许显示
        AllowDelete = 0x0000000000000002,                //在角色管理中允许删除
        AllowEditPermission = 0x0000000000000004,        //在角色权限管理中允许修改
    }
    public enum PermissionType
    {
        Undefined = 0,                           //未定义的权限
        View = 0x0000000000000001,               //浏览帖子
        CreateThread = 0x0000000000000002,       //发表帖子
        EditThread = 0x0000000000000004,         //编辑帖子
        StickThread = 0x0000000000000008,        //置顶帖子
        ModifyThreadStatus = 0x0000000000000010, //修改帖子状态
        DeleteThread = 0x0000000000000020,       //删除帖子
        EditPost = 0x0000000000000040,           //编辑回复
        DeletePost = 0x0000000000000080,         //删除回复
        UserAdmin = 0x0000000000000100,          //用户管理
        RoleAdmin = 0x0000000000000200,          //角色管理
        RolePermissionAdmin = 0x0000000000000400,//角色授权管理
        SectionAdmin = 0x0000000000000800,       //版块及版块分组管理
        SectionAdminsAdmin = 0x0000000000001000, //版主管理
        CloseThread = 0x0000000000002000,        //结贴
        ExceptionLogAdmin = 0x0000000000004000,  //错误日志管理
    }
    public enum AccessControlEntry
    {
        NotSet = 0x00,    //表示未设置允许或不允许
        Allow = 0x01,     //表示允许
        Deny = 0x02       //表示不允许
    }

    public enum ThreadStatus
    {
        Normal = 1,        //一般帖子
        Recommended = 2,   //推荐帖子
        Stick = 3,         //置顶帖子
    }
    public enum ThreadReleaseStatus
    {
        Open = 1,         //未解决帖子
        Close = 2,        //已解决帖子
        Deleted = 3,      //已删除帖子
    }

    public enum ValidationError
    {
        DuplicateRoleName,                 //角色名重复
        GroupNull,
        SectionNull,
        RoleNull,
        UserNull,
        GroupIdNotHasValue,                //版块组ID为空
        GroupNotExist,                     //版块组不存在
        GroupSubjectNotHasValue,           //版块组名为空
        SectionIdNotHasValue,              //版块ID为空
        SectionNotExist,                   //版块不存在
        SectionSubjectNotHasValue,         //版块名为空
        RoleNotExist,                      //和版块关联的角色不存在
        UserNotExist,                      //和版块关联的用户不存在
        ThreadNotExist,
        ThreadAuthorNotExist,
        ThreadAuthorNotHaveEnoughMarks,
        ThreadSectionNotExist,
        PostNotExist,
        PostAlreadyExist,
        CloseThreadTotalMarksNotMatch,
    }
}
