using System;
using System.Web.Mvc;
using CompanyName.ProductName.Common;
using CompanyName.ProductName.Modules.Forum.Services;
using CompanyName.ProductName.Modules.Forum.Website.ViewModels;
using CompanyName.ProductName.Modules.Passport.Services;
using CompanyName.ProductName.Mvc.Common;

namespace CompanyName.ProductName.Modules.Forum.Website.Controllers
{
    [HandleError]
    public class AccountController : Controller
    {
        private readonly IMemberService memberService;
        private readonly IUserService userService;

        public AccountController(IMemberService memberService, IUserService userService)
        {
            this.memberService = memberService;
            this.userService = userService;
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost, UnitOfWork]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Guid memberId;
                IValidationState memberValidationState = memberService.CreateMember(model.MemberName, model.Password, out memberId);
                userService.CreateUser(new Models.User() { Id = memberId, UserName = model.MemberName });
                if (!memberValidationState.IsValid)
                {
                    ModelState.MergeError(memberValidationState);
                }
                else
                {
                    FormsAuthenticationService.SignIn(model.MemberName, false);
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }

        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogonViewModel model)
        {
            if (ModelState.IsValid)
            {
                IValidationState validationState = memberService.ValidatePassword(model.MemberName, model.Password);

                if (!validationState.IsValid)
                {
                    ModelState.MergeError(validationState);
                }
                else
                {
                    FormsAuthenticationService.SignIn(model.MemberName, model.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthenticationService.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost, UnitOfWork]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                IValidationState validationState = memberService.ChangePassword(HttpContext.User.Identity.Name, model.OldPassword, model.NewPassword);
                if (!validationState.IsValid)
                {
                    ModelState.MergeError(validationState);
                }
                else
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
            }

            return View(model);
        }

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }
    }
}
