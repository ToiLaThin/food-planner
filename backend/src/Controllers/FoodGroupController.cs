using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1")]
public class FoodGroupController: ControllerBase
{
    private readonly IFoodGroupRepository _foodGroupRepository;
    private readonly IFoodGroupService _foodGroupService;
    public FoodGroupController(IFoodGroupRepository foodGroupRepository, IFoodGroupService foodGroupService)
    {
        _foodGroupRepository = foodGroupRepository;
        _foodGroupService = foodGroupService;
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
        var serviceResult = await _foodGroupService.ValidateExistedAsync(id);
        if (serviceResult.IsFailed || serviceResult.IsException)
            return NotFound(id);
        return Ok(serviceResult.Data);
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
        var serviceResult = await _foodGroupService.ValidateExistedAsync(id, isTracked: true);
        if (serviceResult.IsFailed || serviceResult.IsException)
            return NotFound(id);
        var foodGroupTracked = serviceResult.Data;
        var result = await _foodGroupRepository.EditAsync(foodGroupTracked);
        return Ok(result);
    }

    [HttpDelete]
    [Route("food-groups/{id:int}/delete")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var serviceResult = await _foodGroupService.ValidateExistedAsync(id, isTracked: true);
        if (serviceResult.IsFailed || serviceResult.IsException)
            return NotFound(id);
        var existed = serviceResult.Data;
        var isSuccess = await _foodGroupRepository.DeleteAsync(existed);
        return NoContent();
    }

}