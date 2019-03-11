using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum
{
    public class ThreadCloseMarksNotMatchException : DomainException
    {
        public ThreadCloseMarksNotMatchException(string errorKey, int realMarks, int requiredMarks) : base(errorKey, realMarks, requiredMarks)
        {
        }
    }
}
