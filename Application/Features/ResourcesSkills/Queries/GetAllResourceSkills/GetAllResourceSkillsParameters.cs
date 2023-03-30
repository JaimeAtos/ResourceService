using Application.Parameters;

namespace Application.Features.ResourcesSkills.Queries.GetAllResourceSkills
{
    public class GetAllResourceSkillsParameters : RequestParameter
    {
        public string? ResourceName { get; set; }
        public string? SkillName { get; set; }
        public string? SkillAcceptanceURL { get; set; }
        public bool? IsComplice { get; set; }
    }
}
