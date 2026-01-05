using Microsoft.EntityFrameworkCore;

public interface IFoodGroupRepository
{
    public Task<List<FoodGroup>> GetListAsync();

    public Task<FoodGroup> AddAsync(FoodGroup foodGroup);
}

public class FoodGroupRepository : IFoodGroupRepository
{
    private readonly FoodDbContext _dbContext; 
    public FoodGroupRepository(FoodDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<FoodGroup> AddAsync(FoodGroup foodGroup)
    {
        _dbContext.FoodGroups.Add(foodGroup);
        await _dbContext.SaveChangesAsync();
        return foodGroup;
    }

    public Task<List<FoodGroup>> GetListAsync()
    {
        var result = _dbContext.FoodGroups.AsNoTracking().ToListAsync();
        return result;
    }
}