using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specification
{
    public class PagedResourcesSkillsSpecification : Specification<ResourceSkills>
    {
        public PagedResourcesSkillsSpecification(int pageSize, int pageNumber, string skillName, 
            string skillAcceptanceURL, bool? isCompliance)
        {
            Query.Skip((pageNumber - 1)* pageSize)
            .Take(pageSize);
            
            if (!string.IsNullOrEmpty(skillName))
                Query.Search(x => x.SkillName, "%" + skillName + "%");

            if (!string.IsNullOrEmpty(skillAcceptanceURL))
                Query.Search(x => x.SkillAcceptanceURL, "%" + skillAcceptanceURL + "%");

            if (!string.IsNullOrEmpty(isCompliance.ToString()))
                Query.Search(x => x.IsCompliance.ToString(), "%" + isCompliance + "%");
        }
    }
}
