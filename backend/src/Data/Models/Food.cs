using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class Food
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? FoodGroupId { get; set; }

    public FoodGroup FoodGroup { get; set; }
}

public class FoodEntityConfiguration : IEntityTypeConfiguration<Food>
{
    public void Configure(EntityTypeBuilder<Food> builder)
    {
        builder.ToTable("Foods").HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(255);
        builder.HasOne(x => x.FoodGroup).WithMany(x => x.Foods).HasForeignKey(x => x.FoodGroupId);
        builder.HasIndex(x => x.FoodGroupId).IsClustered(false);
    }
}