using Moq;

namespace food_planner;

public class FoodGroupUnitTests
{
    
    [Fact]
    public async Task GivenFoodGroup_WhenValidateExisted_ReturnServiceSuccess()
    {
        //arrange
        var mockFoodGroupRepo = new Mock<IFoodGroupRepository>();
        mockFoodGroupRepo
            .Setup(x => x.GetAsync(It.IsAny<int>(), It.IsAny<bool>()))
            .ReturnsAsync(new FoodGroup() { Id = 1 });
        IFoodGroupService _service = new FoodGroupService(mockFoodGroupRepo.Object);

        //act
        var result = await _service.ValidateExistedAsync(1);

        //assert
        Assert.Equal(result.IsFailed || result.IsException, false);
        Assert.Equal(result.IsSuccess, true);
    }

    [Fact]
    public async Task GivenNull_WhenValidateExisted_ReturnServiceFailed()
    {
        //arrange
        var mockFoodGroupRepo = new Mock<IFoodGroupRepository>();
        mockFoodGroupRepo
            .Setup(x => x.GetAsync(It.IsAny<int>(), It.IsAny<bool>()))
            .ReturnsAsync((FoodGroup?)null);
        IFoodGroupService _service = new FoodGroupService(mockFoodGroupRepo.Object);

        //act
        var result = await _service.ValidateExistedAsync(1);

        //assert
        Assert.Equal(result.IsFailed || result.IsException, true);
        Assert.Equal(result.IsSuccess, false);
    }
}
