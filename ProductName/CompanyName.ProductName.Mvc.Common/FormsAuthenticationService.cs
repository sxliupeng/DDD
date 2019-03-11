using System.Web;
using System.Web.Security;

namespace CompanyName.ProductName.Mvc.Common
{
    public class FormsAuthenticationService
    {
        public static void SignIn(string memberName, bool createPersistentCookie)
        {
            FormsAuthentication.SetAuthCookie(memberName, createPersistentCookie);
        }

        public static void SignOut()
        {
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
            }
        }
    }
}