using Microsoft.EntityFrameworkCore;

public class FoodDbContext: DbContext
{
    public FoodDbContext(DbContextOptions<FoodDbContext> options): base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new FoodEntityConfiguration());
        modelBuilder.ApplyConfiguration(new FoodGroupEntityConfiguration());
    }

    public DbSet<Food> Foods { get; set; }
    public DbSet<FoodGroup> FoodGroups { get; set; }
}
