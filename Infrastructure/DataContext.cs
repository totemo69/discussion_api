using discussion_api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace discussion_api
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Discussion>(entity =>
      {
        entity.HasMany(e => e.Attendees).WithOne();
      });

      modelBuilder.Entity<Discussion>().Navigation(b => b.Attendees).UsePropertyAccessMode(PropertyAccessMode.Property);
    }

    public DbSet<Discussion> Discussion { get; set; }

    public override int SaveChanges()
    {
      AddTimestamps();
      return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
      AddTimestamps();
      return await base.SaveChangesAsync(cancellationToken);
    }

    private void AddTimestamps()
    {
      var entities = ChangeTracker.Entries()
        .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

      foreach (var entity in entities)
      {
        var now = DateTime.UtcNow;

        if (entity.State == EntityState.Added)
        {
          ((BaseEntity)entity.Entity).createdAt = now;
        }
        ((BaseEntity)entity.Entity).updatedAt = now;
      }
    }

  }
}
