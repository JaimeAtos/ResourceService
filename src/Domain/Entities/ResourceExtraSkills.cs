using Atos.Core.Commons;

namespace Domain.Entities;
public class ResourceExtraSkills : EntityBaseAuditable<Guid, Guid>
{
    public string Title { get; set; }
    public Guid ResourceId { get; set; }
    public string ExperienceOverallTypeTag { get; set; } //Certification, Course,
    public string BriefDescription { get; set; }
    public byte Point { get; set; } // 0 to 100. This field is used by the mentor to validate the experience
    public bool IsApproved { get; set; }
    public Resource Resource { get; set; } = null!;
}
