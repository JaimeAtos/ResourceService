using Application.Interfaces;
using Atos.EFCore.Extensions;
using Domain.Commons;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Security;

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
    

    //TODO: comentar a Daniel acerca de que este metodo forsozamente nos pide un int como retorno, en vez de un guid
    public override Task<int> SaveChangesAsync(CancellationToken cancellation = new CancellationToken())
    {
        //TODO: agregar despues la AuditableEntityBase
        foreach (var entry in base.ChangeTracker.Entries<EntityBase<Guid, Guid>>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = _dateTime.NowUtc;
                    entry.Entity.State = true;
                    break;
                //case EntityState.Modified:
                //    break;
                default:
                    break;
            }
        }
        return base.SaveChangesAsync(cancellation);
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder);
    //    modelBuilder.RegisterEntityConfigurations<ResourceDbContext>();
    //}
}
