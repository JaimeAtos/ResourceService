using Application.Interfaces;
using Atos.Core.Commons;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts;
public class ResourceDbContext : DbContext
{
    private readonly IDateTimeService _dateTime;

    public ResourceDbContext(DbContextOptions options, IDateTimeService dateTime) : base(options)
    {
        _dateTime=dateTime;
    }

    public DbSet<Resource> Resource { get; set; }
    public DbSet<ResourceExtraSkills> ResourceExtraSkills { get; set; }
    public DbSet<ResourceSkills> ResourceSkills { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellation = new CancellationToken())
    {
        foreach (var entry in base.ChangeTracker.Entries<EntityBaseAuditable<Guid, Guid>>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.Id = Guid.NewGuid();
                    entry.Entity.CreatedDate = _dateTime.NowUtc;
                    entry.Entity.State = true;
                    break;
                case EntityState.Modified:
                    entry.Entity.DateLastModify = _dateTime.NowUtc;
                    break;
                default:
                    break;
            }
        }
        return base.SaveChangesAsync(cancellation);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ResourceSkills>()
            .HasOne(e => e.Resource)
            .WithMany(e => e.ResourceSkills)
            .HasForeignKey(e => e.ResourceId)
            .IsRequired();
        
        modelBuilder.Entity<ResourceExtraSkills>()
            .HasOne(e => e.Resource)
            .WithMany(e => e.ResourceExtraSkills)
            .HasForeignKey(e => e.ResourceId)
            .IsRequired();
    }
    
}
