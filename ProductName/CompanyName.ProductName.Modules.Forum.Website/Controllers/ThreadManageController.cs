using System.Web.Mvc;

namespace CompanyName.ProductName.Modules.Forum.Website.Controllers
{
    [HandleError]
    public class ThreadManageController : Controller
    {
        public ActionResult MyThreads()
        {
            return View();
        }

        public ActionResult MyReplyThreads()
        {
            return View();
        }

        public ActionResult MyOpenThreads()
        {
            return View();
        }

        public ActionResult MyCloseThreads()
        {
            return View();
        }
    }
}
