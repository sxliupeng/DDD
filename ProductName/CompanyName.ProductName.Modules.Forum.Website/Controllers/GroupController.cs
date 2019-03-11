using System;
using System.Web.Mvc;
using EventBasedDDD;
using CompanyName.ProductName.Modules.Forum.ApplicationServices;
using CompanyName.ProductName.Modules.Forum.Website.ViewData;

namespace CompanyName.ProductName.Modules.Forum.Website.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupService groupService;

        public GroupController(IGroupService groupService)
        {
            this.groupService = groupService;
        }

        public ActionResult Index()
        {
            return View(groupService.GetPagedGroups(new GetPagedGroupDataRequest() { PageIndex = 0, PageSize = 20 }).PageData.ToViewData());
        }

        public ActionResult Details(Guid id)
        {
            return View(groupService.GetGroup(new GetDataRequest<Guid> { Id = id }).Data.ToViewData());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateGroupViewData model)
        {
            if (ModelState.IsValid)
            {
                BaseReply reply = groupService.CreateGroup(new CreateGroupRequest { Subject = model.Subject, Enabled = model.Enabled });
                if (!reply.Success)
                {
                    ModelState.MergeError(reply.ErrorState);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        public ActionResult Edit(Guid id)
        {
            return View(groupService.GetGroup(new GetDataRequest<Guid> { Id = id }).Data.ToViewData());
        }

        [HttpPost]
        public ActionResult Edit(GroupViewData model)
        {
            if (ModelState.IsValid)
            {
                BaseReply reply = groupService.UpdateGroup(new UpdateGroupRequest { Id = model.Id, Subject = model.Subject, Enabled = model.Enabled });
                if (!reply.Success)
                {
                    ModelState.MergeError(reply.ErrorState);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
    }
}
