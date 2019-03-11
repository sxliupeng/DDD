using System;
using CompanyName.ProductName.Modules.Forum.DomainEvents;
using CompanyName.ProductName.Modules.Forum.DomainObjects;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public class SectionService : BaseService, ISectionService
    {
        private IForumQueryService queryService;

        public SectionService(IForumQueryService queryService)
        {
            this.queryService = queryService;
        }

        public GetDataListReply<SectionData> GetSections(GetSectionDataListRequest request)
        {
            return new GetDataListReply<SectionData>
            {
                DataList = queryService.GetSections(request.GroupId, request.Subject, request.Enabled)
            };
        }
        public GetPagedDataReply<SectionData> GetPagedSections(GetPagedSectionDataRequest request)
        {
            return new GetPagedDataReply<SectionData>
            {
                PageData = queryService.GetPagedSections(request.GroupId, request.Subject, request.Enabled, request.PageIndex, request.PageSize)
            };
        }
        public GetDataReply<SectionData> GetSection(GetDataRequest<Guid> request)
        {
            return new GetDataReply<SectionData>
            {
                Data = queryService.GetSection(request.Id)
            };
        }
        public BaseReply CreateSection(CreateSectionRequest request)
        {
            return ProcessRequest(
                () =>
                {
                    Repository.Add(new Section(request.GroupId, request.Subject) { Enabled = request.Enabled });
                });
        }
        public BaseReply UpdateSection(UpdateSectionRequest request)
        {
            return ProcessRequest(
                () =>
                {
                    var section = Repository.Get<Section, Guid>(request.Id);
                    EventProcesser.ProcessEvent(new ChangeSectionSubjectEvent { SectionId = request.Id, NewSubject = request.Subject });
                    section.Enabled = request.Enabled;
                    section.GroupId = request.GroupId;
                });
        }
        public BaseReply AddSectionRoleUser(AddSectionRoleUserRequest request)
        {
            return ProcessRequest(
                () =>
                {
                    EventProcesser.ProcessEvent(new AddSectionRoleUserEvent { SectionId = request.SectionId, RoleId = request.RoleId, UserId = request.UserId });
                });
        }
        public BaseReply RemoveSectionRoleUser(RemoveSectionRoleUserRequest request)
        {
            return ProcessRequest(
                () =>
                {
                    EventProcesser.ProcessEvent(new RemoveSectionRoleUserEvent { SectionId = request.SectionId, RoleId = request.RoleId, UserId = request.UserId });
                });
        }
    }
}
