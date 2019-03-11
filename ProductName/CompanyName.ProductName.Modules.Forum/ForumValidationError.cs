namespace CompanyName.ProductName.Modules.Forum
{
    public enum ForumValidationError
    {
        DuplicateRoleName,
        GroupNotExist,
        SectionNotExist,
        RoleNotExist,
        UserNotExist,
        ThreadNotExist,
        ThreadAuthorNotExist,
        ThreadAuthorNotHaveEnoughMarks,
        ThreadSectionNotExist,
        ThreadAuthorTotalMarksNotEnough,
        DeleteThreadFailed,
        CloseThreadTotalMarksNotMatch,
        PostNotExist,
        PostAuthorNotExist,
        DeletePostFailed,
        BatchDeletePostFailed,
        DuplicateGroupSubject,
        DuplicateSectionSubject,
        DuplicateUserName,
        DeleteRoleFailed,
        ExceptionLogNotExist,
        DeleteExceptionLogFailed
    }
}
