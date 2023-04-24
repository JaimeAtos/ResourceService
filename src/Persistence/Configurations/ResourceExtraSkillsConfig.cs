using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ResourceExtraSkillsConfig : IEntityTypeConfiguration<ResourceExtraSkills>
{
    public void Configure(EntityTypeBuilder<ResourceExtraSkills> builder)
    {
        builder.ConfigurationBase<Guid, Guid, ResourceExtraSkills>("ResourcesExtraSkills");
        builder.Property(p => p.Title).HasDefaultValue("nvarchar(50)");
        builder.Property(p => p.ExperienceOverallTypeTag).HasDefaultValue("nvarchar(30)");
        builder.Property(p => p.BriefDescription).HasDefaultValue("nvarchar(60)");
        builder.Property(p => p.Point).HasMaxLength(3);
        builder.Property(p => p.IsApproved).HasMaxLength(1);
    }

}
