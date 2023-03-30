using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specification
{
    public class PagedResourcesSkillsSpecification : Specification<ResourceSkills>
    {
        public PagedResourcesSkillsSpecification(int pageSize, int pageNumber, string resourceName, string skillName, 
            string skillAcceptanceURL, bool? isComplice)
        {
            Query.Skip((pageNumber - 1)* pageSize)
            .Take(pageSize);

            if (!string.IsNullOrEmpty(resourceName))
                Query.Search(x => x.ResourceName, "%" + resourceName + "%");

            if (!string.IsNullOrEmpty(skillName))
                Query.Search(x => x.SkillName, "%" + skillName + "%");

            if (!string.IsNullOrEmpty(skillAcceptanceURL))
                Query.Search(x => x.SkillAcceptanceURL, "%" + skillAcceptanceURL + "%");

            if (!string.IsNullOrEmpty(isComplice.ToString()))
                Query.Search(x => x.IsComplice.ToString(), "%" + isComplice + "%");
        }
    }
}
