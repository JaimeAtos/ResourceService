using Atos.EFCore.Extensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations;

public class ResourceSkillsConfig : IEntityTypeConfiguration<ResourceSkills>
{
    public void Configure(EntityTypeBuilder<ResourceSkills> builder)
    {
        builder.ConfigurationBase<Guid, Guid, ResourceSkills>("ResourcesSkills");
        builder.Property(p => p.Id).HasDefaultValue("NEWID()");

        builder.Property(p => p.SkillId).HasDefaultValue("UNIQUEIDENTIFIER");
        builder.Property(p => p.ResourceId).HasDefaultValue("UNIQUEIDENTIFIER");
        builder.Property(p => p.ResourceName).HasDefaultValue("varchar(80)");
        builder.Property(p => p.SkillName).HasDefaultValue("UNIQUEIDENTIFIER");
        builder.Property(p => p.IsComplice).HasMaxLength(80);
    }
}
