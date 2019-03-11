using System;
using System.Linq;
using System.Web.Mvc;
using CompanyName.ProductName.Modules.Forum.ApplicationServices;
using CompanyName.ProductName.Modules.Forum.Website.ViewData;
using MvcContrib;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.Website.Controllers
{
    public class SectionController : Controller
    {
        private readonly ISectionService sectionService;
        private readonly IGroupService groupService;

        public SectionController(ISectionService sectionService, IGroupService groupService)
        {
            this.sectionService = sectionService;
            this.groupService = groupService;
        }

        public ActionResult Index(Guid groupId)
        {
            return View(sectionService.GetPagedSections(new GetPagedSectionDataRequest() { GroupId = groupId, PageIndex = 0, PageSize = 20 }).PageData.ToViewData());
        }

        public ActionResult Details(Guid id)
        {
            return View(sectionService.GetSection(new GetDataRequest<Guid> { Id = id }).Data.ToViewData());
        }

        public ActionResult Create()
        {
            CreateSectionViewData viewData = new CreateSectionViewData();
            viewData.Groups = groupService.GetGroups(new GetGroupDataListRequest()).DataList.ToList();
            return View(viewData);
        }

        [HttpPost]
        public ActionResult Create(CreateSectionViewData model)
        {
            model.Groups = groupService.GetGroups(new GetGroupDataListRequest()).DataList.ToList();
            if (ModelState.IsValid)
            {
                BaseReply reply = sectionService.CreateSection(new CreateSectionRequest { Subject = model.Subject, Enabled = model.Enabled, GroupId = model.GroupId });
                if (!reply.Success)
                {
                    ModelState.MergeError(reply.ErrorState);
                }
                else
                {
                    return this.RedirectToAction(s => s.Index(model.GroupId));
                }
            }
            return View(model);
        }

        public ActionResult Edit(Guid id)
        {
            var viewData = sectionService.GetSection(new GetDataRequest<Guid> { Id = id }).Data.ToEditViewData();
            viewData.Groups = groupService.GetGroups(new GetGroupDataListRequest()).DataList.ToList();
            return View(viewData);
        }

        [HttpPost]
        public ActionResult Edit(EditSectionViewData model)
        {
            model.Groups = groupService.GetGroups(new GetGroupDataListRequest()).DataList.ToList();
            if (ModelState.IsValid)
            {
                BaseReply reply = sectionService.UpdateSection(new UpdateSectionRequest { Id = model.Id, Subject = model.Subject, Enabled = model.Enabled, GroupId = model.GroupId });
                if (!reply.Success)
                {
                    ModelState.MergeError(reply.ErrorState);
                }
                else
                {
                    return this.RedirectToAction(s => s.Index(model.GroupId));
                }
            }
            return View(model);
        }
    }
}
