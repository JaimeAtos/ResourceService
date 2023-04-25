using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ResourceConfig : IEntityTypeConfiguration<Resource>
{
    public void Configure(EntityTypeBuilder<Resource> builder)
    {
        builder.ConfigurationBase<Guid, Guid, Resource>("Resources");

        builder.Property(p => p.ResourceName).HasDefaultValue("varchar(80)");
        builder.Property(p => p.WorkEmail).HasDefaultValue("nvarchar(120)");
        builder.Property(p => p.PersonalEmail).HasDefaultValue("varchar(120)");
        builder.Property(p => p.Phone).HasDefaultValue("varchar(10)");
        builder.Property(p => p.CurrentStateDescription).HasDefaultValue("nvarchar(30)");
        builder.Property(p => p.CurrentPositionDescription).HasDefaultValue("nvarchar(120)");
        builder.Property(p => p.PersonalEmail).HasDefaultValue("nvarchar(120)");
        builder.Property(p => p.LocationDescription).HasDefaultValue("nvarchar(50)");
        builder.Property(p => p.NessieID).HasDefaultValue("nvarchar(10)");
        builder.Property(p => p.CurrentClientName).HasDefaultValue("nvarchar(80)");
        builder.Property(p => p.IsNational).HasColumnType("bit").IsRequired();
        builder.Property(p => p.Gcm).HasColumnType("byte").IsRequired();
    }
}
