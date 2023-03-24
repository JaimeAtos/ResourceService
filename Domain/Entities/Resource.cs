using Domain.Commons;

namespace Domain.Entities;
public class Resource : PersonaAuditable<Guid, Guid>
{
    public string? ResumeUrl { get; set; }
    public string? WorkEmail { get; set; }
    public string? PersonalEmail { get; set; }
    public string? Phone { get; set; }
    public Guid CurrentStateId { get; set; }
    public string? CurrentStateDescription { get; set; }
    public Guid? CurrentPositionId { get; set; }
    public string? CurrentPositionDescription { get; set; }
    public Guid? LocationId { get; set; }
    public string? LocationDescription { get; set; }
    public string? NessieID { get; set; }
    public Guid? CurrentClientId { get; set; }
    public string? CurrentClientName { get; set; }
}

