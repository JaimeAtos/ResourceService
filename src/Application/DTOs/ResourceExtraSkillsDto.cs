namespace Application.DTOs
{
    public class ResourceExtraSkillsDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ExperienceOverallTypeTag { get; set; }
        public string BriefDescription { get; set; }
        public byte Point { get; set; }
        public bool IsApproved { get; set; }
        public Guid ResourceId { get; set; }
    }
}
