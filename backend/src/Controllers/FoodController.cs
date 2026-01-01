using Microsoft.AspNetCore.Mvc;

public record PaginateCommand
{
    public int Page { get; set; } = 1;
    public int Step { get; set; } = 3;

    string Search { get; set; } = null;
}

[Route("api/v1")]
[ApiController]
public class FoodController: ControllerBase
{

    private readonly IFoodRepository _foodRepository;
    public FoodController(IFoodRepository foodRepository)
    {
        _foodRepository = foodRepository;
    }

    [HttpGet]
    [Route("foods")]
    public async Task<IActionResult> GetPaginatedList([FromQuery] PaginateCommand command)
    {
        var result = await _foodRepository.GetPaginatedListAsync(command);
        return Ok(result); //200
    }

    [HttpGet]
    [Route("foods/{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _foodRepository.GetByIdAsync(id);
        if (result is null)
            return NotFound(); //404
        return Ok(result); //200
    }

    [HttpPost]
    [Route("foods/{id:int}")]
    public async Task<IActionResult> Add([FromBody] Food food)
    {
        var result = await _foodRepository.AddAsync(food);
        return Ok(result);
    }
}