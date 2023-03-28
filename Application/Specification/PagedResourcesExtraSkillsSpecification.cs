using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specification;

public class PagedResourcesExtraSkillsSpecification : Specification<ResourceExtraSkills>
{
    public PagedResourcesExtraSkillsSpecification(int pageSize, int pageNumber, string title, string experienceOveralTypeTag,
        string briefdescription, bool? isApproved)
    {
        Query.Skip((pageNumber -1) * pageSize)
            .Take(pageSize);

        if(!string.IsNullOrEmpty(title))
            Query.Search(x => x.Title, "%" + title + "%");

        if (!string.IsNullOrEmpty(experienceOveralTypeTag))
            Query.Search(x => x.ExperienceOveralTypeTag, "%" + experienceOveralTypeTag + "%");

        if (!string.IsNullOrEmpty(briefdescription))
            Query.Search(x => x.BriefDescription, "%" + briefdescription + "%");

        if (!string.IsNullOrEmpty(isApproved.ToString()))
            Query.Search(x => x.IsApproved.ToString(), "%" + isApproved + "%");
    }
}
