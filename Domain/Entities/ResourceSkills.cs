using Domain.Commons;

namespace Domain.Entities;
public class ResourceSkills : EntityBase<Guid, Guid>
{
    public Guid SkillId { get; set; }
    public Guid ResourceId { get; set; }
    public string ResourceName { get; set; }
    public Guid SkillName { get; set; }
    public string SkillAcceptanceURL { get; set; } // Evidences of Validations
    public bool IsComplice { get; set; } // False if resource needs to revalidate the skill
}
