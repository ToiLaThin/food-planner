using Microsoft.AspNetCore.Mvc;

public class Food
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? FoodGroupId { get; set; }
}

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
    [HttpGet]
    [Route("foods")]
    public async Task<IActionResult> GetPaginatedList([FromQuery] PaginateCommand command)
    {
        var result = new List<Food>()
        {
            new Food() { Id = 1, Name = "Chicken" },
            new Food() { Id = 2, Name = "Egg" },
        };
        return Ok(result); //200
    }

    [HttpGet]
    [Route("foods/{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var foods = new List<Food>()
        {
            new Food() { Id = 1, Name = "Chicken" },
            new Food() { Id = 2, Name = "Egg" },
        };
        var result = foods.Where(x => x.Id == id).FirstOrDefault();
        if (result is null)
            return NotFound(); //404
        return Ok(result); //200
    }
}