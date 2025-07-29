using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<MediaModel> Media { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MediaModel>(entity =>
        {
            entity.HasKey(e => e.ID);

            entity.OwnsMany(e => e.Details, detail =>
            {
                detail.WithOwner().HasForeignKey("MediaModelID");
                detail.Property<int>("DetailId");
                detail.HasKey("DetailId");
            });
        });
        base.OnModelCreating(modelBuilder);
    }
}