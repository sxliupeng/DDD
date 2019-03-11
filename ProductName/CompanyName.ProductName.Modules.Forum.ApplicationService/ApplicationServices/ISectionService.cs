using System;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.ApplicationServices
{
    public interface ISectionService
    {
        GetDataListReply<SectionData> GetSections(GetSectionDataListRequest request);
        GetPagedDataReply<SectionData> GetPagedSections(GetPagedSectionDataRequest request);
        GetDataReply<SectionData> GetSection(GetDataRequest<Guid> request);
        BaseReply CreateSection(CreateSectionRequest request);
        BaseReply UpdateSection(UpdateSectionRequest request);
        BaseReply AddSectionRoleUser(AddSectionRoleUserRequest request);
        BaseReply RemoveSectionRoleUser(RemoveSectionRoleUserRequest request);
    }
}
