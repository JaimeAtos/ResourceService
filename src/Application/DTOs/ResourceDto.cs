namespace Application.DTOs;

public class ResourceDto
{
    public Guid Id { get; set; }
    public string ResourceName { get; set; }
    public bool State { get; set; }
    public string ResumeUrl { get; set; }
    public string WorkEmail { get; set; }
    public string Phone { get; set; }
    public string CurrentStateDescription { get; set; }
    public string CurrentPositionDescription { get; set; }
    public string LocationDescription { get; set; }
    public string NessieID { get; set; }
    public string CurrentClientName { get; set; }
    public bool IsNational { get; set; }
    public byte Gcm {get ; set;}
    public ICollection<ResourceSkillsDto> ResourceSkills { get; set; } = new List<ResourceSkillsDto>();
    public ICollection<ResourceExtraSkillsDto> ResourceExtraSkills { get; set; } = new List<ResourceExtraSkillsDto>();
}
