using Microsoft.EntityFrameworkCore;

public interface IFoodGroupRepository
{
    public Task<List<FoodGroup>> GetListAsync();

    public Task<FoodGroup> GetAsync(int id, bool isTracked = false);

    public Task<FoodGroup> AddAsync(FoodGroup foodGroup);

    public Task<FoodGroup> EditAsync(FoodGroup foodGroup);

    public Task<bool> DeleteAsync(FoodGroup foodGroup);
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

    public async Task<bool> DeleteAsync(FoodGroup foodGroup)
    {
        _dbContext.FoodGroups.Remove(foodGroup);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<FoodGroup> EditAsync(FoodGroup foodGroup)
    {
        _dbContext.FoodGroups.Update(foodGroup);
        await _dbContext.SaveChangesAsync();
        return foodGroup;
    }

    public async Task<FoodGroup> GetAsync(int id, bool isTracked = false)
    {
        var query = _dbContext.FoodGroups.AsQueryable();
        if (!isTracked)
            query = query.AsNoTracking();
        var result = await query.FirstOrDefaultAsync(gr => gr.Id == id);
        return result;
    }

    public Task<List<FoodGroup>> GetListAsync()
    {
        var result = _dbContext.FoodGroups.AsNoTracking().ToListAsync();
        return result;
    }
}