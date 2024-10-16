using Microsoft.EntityFrameworkCore;

namespace AI.Project.Entities;

public class ProjectDbContext : DbContext
{
    public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<AggregateEntity> Aggregates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AggregateEntity>(entity =>
        {
            entity.ToTable("aggregates");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id").HasColumnType("bigint").UseIdentityAlwaysColumn();
            entity.Property(e => e.Name).HasColumnName("name").HasColumnType("text").IsRequired();
        });
    }
}