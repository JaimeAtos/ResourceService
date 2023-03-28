using Application.Parameters;

namespace Application.Features.ResourcesExtraSkills.Queries.GetAllResourcesExtraSkills;

public class GetAllResourcesExtraSkillsParameters : RequestParameter
{
    public string? Title { get; set; }
    public string? ExperienceOveralTypeTag { get; set; }
    public string? BriefDescription { get; set; }
    public bool? IsApproved { get; set; }
}