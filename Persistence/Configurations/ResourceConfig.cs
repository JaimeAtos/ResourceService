using Atos.EFCore.Extensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ResourceConfig : IEntityTypeConfiguration<Resource>
{
    public void Configure(EntityTypeBuilder<Resource> builder)
    {
        builder.ConfigurationBase<Guid, Guid, Resource>("Resources");
        builder.Property(p => p.Id).HasDefaultValue("NEWID()");

        builder.Property(p => p.WorkEmail).HasDefaultValue("nvarchar(120)");
        builder.Property(p => p.PersonalEmail).HasDefaultValue("varchar(120)");
        builder.Property(p => p.Phone).HasDefaultValue("varchar(10)");
        builder.Property(p => p.CurrentStateId).HasDefaultValue("UNIQUEIDENTIFIER");
        builder.Property(p => p.CurrentStateDescription).HasDefaultValue("nvarchar(30)");
        builder.Property(p => p.CurrentPositionId).HasDefaultValue("UNIQUEIDENTIFIER");
        builder.Property(p => p.CurrentPositionDescription).HasDefaultValue("nvarchar(120)");
        builder.Property(p => p.PersonalEmail).HasDefaultValue("nvarchar(120)");
        builder.Property(p => p.LocationId).HasDefaultValue("UNIQUEIDENTIFIER");
        builder.Property(p => p.LocationDescription).HasDefaultValue("nvarchar(50)");
        builder.Property(p => p.NessieID).HasDefaultValue("nvarchar(10)");
        builder.Property(p => p.CurrentClientId).HasDefaultValue("UNIQUEIDENTIFIER");
        builder.Property(p => p.CurrentClientName).HasDefaultValue("nvarchar(80)");
    }
}
