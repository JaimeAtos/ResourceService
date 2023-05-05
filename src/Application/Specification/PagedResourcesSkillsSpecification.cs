using Application.Features.ResourcesSkills.Queries.GetAllResourceSkills;
using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specification
{
    public class PagedResourcesSkillsSpecification : Specification<ResourceSkills>
    {
        public PagedResourcesSkillsSpecification(GetAllResourceSkillsQuery request)
        {
            Query.Skip((request.PageNumber)* request.PageSize)
            .Take(request.PageSize);
            
            if (!string.IsNullOrEmpty(request.SkillName))
                Query.Search(x => x.SkillName, "%" + request.SkillName + "%");

            if (!string.IsNullOrEmpty(request.SkillAcceptanceURL))
                Query.Search(x => x.SkillAcceptanceURL, "%" + request.SkillAcceptanceURL + "%");

            if (!string.IsNullOrEmpty(request.IsCompliance.ToString()))
                Query.Search(x => x.IsCompliance.ToString(), "%" + request.IsCompliance + "%");
            
            Query.Search(x => x.State.ToString(), request.State.ToString());
        }
    }
}
