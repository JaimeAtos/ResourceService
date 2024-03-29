﻿using Application.Parameters;

namespace Application.Features.ResourcesExtraSkills.Queries.GetAllResourcesExtraSkills;

public class GetAllResourcesExtraSkillsParameters : RequestParameter
{
    public string? Title { get; set; }
    public string? ExperienceOverallTypeTag { get; set; }
    public string? BriefDescription { get; set; }
    public bool? IsApproved { get; set; }
    public bool State { get; set; }
}