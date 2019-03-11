using System.Web.Mvc;
using AutoMapper;
using CompanyName.ProductName.Common;
using CompanyName.ProductName.Modules.Forum.Services;
using CompanyName.ProductName.Modules.Forum.Website.ViewModels;
using CompanyName.ProductName.Mvc.Common;

namespace CompanyName.ProductName.Modules.Forum.Website.Controllers
{
    [HandleError]
    [Authorize]
    public class ControlPanelController : Controller
    {
        private readonly IUserService userService;

        public ControlPanelController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditProfile()
        {
            return View(Mapper.Map<Models.User, EditUserProfileViewModel>(userService.GetUser(HttpContext.User.Identity.Name)));
        }

        [HttpPost, UnitOfWork]
        public ActionResult EditProfile(EditUserProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = userService.GetUser(HttpContext.User.Identity.Name);
                user = Mapper.Map<EditUserProfileViewModel, Models.User>(model, user);
                IValidationState validationState = userService.UpdateUser(user);
                if (!validationState.IsValid)
                {
                    ModelState.MergeError(validationState);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

        public ActionResult EditProfileSuccess()
        {
            return View();
        }

        public ActionResult EditAvatar()
        {
            return View();
        }
    }
}
