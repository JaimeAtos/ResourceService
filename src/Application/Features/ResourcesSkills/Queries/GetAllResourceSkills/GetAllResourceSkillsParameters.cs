using Application.Parameters;

namespace Application.Features.ResourcesSkills.Queries.GetAllResourceSkills
{
    public class GetAllResourceSkillsParameters : RequestParameter
    {
        public string? SkillName { get; set; }
        public string? SkillAcceptanceURL { get; set; }
        public bool? IsCompliance { get; set; }
    }
}
