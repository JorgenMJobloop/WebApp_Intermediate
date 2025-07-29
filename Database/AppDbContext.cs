using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<MediaModel> MediaDB { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MediaModel>(entity =>
        {
            entity.HasKey(e => e.ID);
            entity.Property(e => e.UUID).IsRequired();

            entity.OwnsMany(m => m.Details, detail =>
            {
                detail.WithOwner().HasForeignKey("MediaModelID");
                detail.Property<int>("ID");
                detail.HasKey("ID");
            });
        });
        base.OnModelCreating(modelBuilder);
    }
}