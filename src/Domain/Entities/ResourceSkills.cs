using Atos.Core.Commons;

namespace Domain.Entities;
public class ResourceSkills : EntityBaseAuditable<Guid, Guid>
{
    public Guid SkillId { get; set; }
    public Guid ResourceId { get; set; }
    public string SkillName { get; set; }
    public string SkillAcceptanceURL { get; set; } // Evidences of Validations
    public bool IsCompliance { get; set; } // False if resource needs to revalidate the skill
}
