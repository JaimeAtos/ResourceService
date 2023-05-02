namespace Application.DTOs
{
    public class ResourceSkillsDto
    {
        public Guid Id { get; set; }
        public string SkillName { get; set; }
        public string SkillAcceptanceURL { get; set; } 
        public bool IsCompliance { get; set; }
        public Guid ResourceId { get; set; }
    }
}
