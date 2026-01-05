using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1")]
public class FoodGroupController: ControllerBase
{
    private readonly IFoodGroupRepository _foodGroupRepository;
    public FoodGroupController(IFoodGroupRepository foodGroupRepository)
    {
        _foodGroupRepository = foodGroupRepository;
    }


    [HttpGet]
    [Route("food-groups")]
    public async Task<IActionResult> GetList()
    {
        var results = await _foodGroupRepository.GetListAsync();
        return Ok(results);
    }

    [HttpPost]
    [Route("food-groups")]
    public async Task<IActionResult> Add(FoodGroup foodGroup)
    {
        var results = await _foodGroupRepository.AddAsync(foodGroup);
        return Ok(results);
    }
}