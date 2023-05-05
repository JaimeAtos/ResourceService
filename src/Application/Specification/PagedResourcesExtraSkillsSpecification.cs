using Application.Features.ResourcesExtraSkills.Queries.GetAllResourcesExtraSkills;
using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specification;

public class PagedResourcesExtraSkillsSpecification : Specification<ResourceExtraSkills>
{
    public PagedResourcesExtraSkillsSpecification(GetAllResourcesExtraSkillsQuery request)
    {
        Query.Skip((request.PageNumber) * request.PageSize)
            .Take(request.PageSize);

        if(!string.IsNullOrEmpty(request.Title))
            Query.Search(x => x.Title, "%" + request.Title + "%");

        if (!string.IsNullOrEmpty(request.ExperienceOverallTypeTag))
            Query.Search(x => x.ExperienceOverallTypeTag, "%" + request.ExperienceOverallTypeTag + "%");

        if (!string.IsNullOrEmpty(request.BriefDescription))
            Query.Search(x => x.BriefDescription, "%" + request.BriefDescription + "%");

        if (!string.IsNullOrEmpty(request.IsApproved.ToString()))
            Query.Search(x => x.IsApproved.ToString(), "%" + request.IsApproved + "%");
        
        Query.Search(x => x.State.ToString(), request.State.ToString());
    }
}
