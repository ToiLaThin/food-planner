using Microsoft.EntityFrameworkCore;

public interface IFoodRepository
{
    public Task<List<Food>> GetPaginatedListAsync(PaginateCommand command);
    public Task<Food> GetByIdAsync(int id);
    public Task<Food> AddAsync(Food food);
}

public class FoodRepository : IFoodRepository
{
    private FoodDbContext _dbContext;
    public FoodRepository(FoodDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Food> AddAsync(Food food)
    {
        _dbContext.Foods.Add(food);
        await _dbContext.SaveChangesAsync();
        return food; //populated with generated id
    }

    public async Task<Food> GetByIdAsync(int id)
    {
        var result = await _dbContext.Foods
            .AsQueryable().AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
        return result;
    }

    public async Task<List<Food>> GetPaginatedListAsync(PaginateCommand command)
    {
        var result = await _dbContext.Foods
            .AsQueryable()
            .AsNoTracking()
            .OrderByDescending(x => x.Id)
            .Skip((command.Page - 1) * command.Step)
            .Take(command.Step)
            .ToListAsync();
        return result;
    }


}