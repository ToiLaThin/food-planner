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

    [HttpGet]
    [Route("food-groups/{id:int}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var results = await _foodGroupRepository.GetAsync(id);
        if (results is null)
            return NotFound(id);
        return Ok(results);
    }

    [HttpPost]
    [Route("food-groups")]
    public async Task<IActionResult> Add([FromBody] FoodGroup foodGroup)
    {
        var results = await _foodGroupRepository.AddAsync(foodGroup);
        return Ok(results);
    }

    [HttpPut]
    [Route("food-groups/{id:int}/edit")]
    public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] FoodGroup foodGroup)
    {
        var existed = await _foodGroupRepository.GetAsync(id, isTracked: false);
        if (existed is null)
            return NotFound(id);
        var result = await _foodGroupRepository.EditAsync(foodGroup);
        return Ok(result);
    }

    [HttpDelete]
    [Route("food-groups/{id:int}/delete")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var existed = await _foodGroupRepository.GetAsync(id, isTracked: true);
        if (existed is null)
            return NotFound(id);
        var isSuccess = await _foodGroupRepository.DeleteAsync(existed);
        return NoContent();
    }

}