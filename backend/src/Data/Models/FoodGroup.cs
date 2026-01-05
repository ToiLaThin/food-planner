using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class FoodGroup
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string MainBenefit { get; set; }

    public ICollection<Food> Foods { get; set; }
}

public class FoodGroupEntityConfiguration : IEntityTypeConfiguration<FoodGroup>
{
    public void Configure(EntityTypeBuilder<FoodGroup> builder)
    {
        builder
            .ToTable("FoodGroups")
            .HasKey(x => x.Id);

        builder.Property(x => x.Name).HasMaxLength(255);
    }
}