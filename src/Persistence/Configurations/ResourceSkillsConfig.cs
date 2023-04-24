using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ResourceSkillsConfig : IEntityTypeConfiguration<ResourceSkills>
{
    public void Configure(EntityTypeBuilder<ResourceSkills> builder)
    {
        builder.ConfigurationBase<Guid, Guid, ResourceSkills>("ResourcesSkills");
        builder.Property(p => p.IsCompliance).HasMaxLength(80);
    }
}
