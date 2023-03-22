﻿using Domain.Commons;

namespace Domain.Entities;
public class ResourceExtraSkills : PersonaAuditable<Guid, Guid>
{
    public string Title { get; set; }
    public string ResourceId { get; set; }
    public string ExperienceOveralTypeTag { get; set; } //Certification, Course,
    public string BriefDescription { get; set; }
    public byte Point { get; set; } // 0 to 100. This field is used by the mentor to validate the experience
    public bool IsApproved { get; set; }
}
