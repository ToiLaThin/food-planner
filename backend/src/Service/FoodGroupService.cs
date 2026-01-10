public enum ResultType
{
    Success = 0,
    Failed = 1,
    Exception = 2
}

public class ServiceResult<T> where T: class
{
    public T Data { get; private set; }

    public ResultType Result { get; private set; }

    public string Error { get; private set; }

    public bool IsSuccess => Result == ResultType.Success;
    public bool IsFailed => Result == ResultType.Failed;
    public bool IsException => Result == ResultType.Exception;

    public static ServiceResult<T> Success(T result)
    {
        return new ServiceResult<T>()
        {
            Data = result,
            Result = ResultType.Success,
            Error = null,
        };
    }

    public static ServiceResult<T> Failure(string errorMessage)
    {
        return new ServiceResult<T>()
        {
            Data = default(T),
            Result = ResultType.Failed,
            Error = errorMessage,
        };
    }

    public static ServiceResult<T> Exception(string exceptionMessage)
    {
        return new ServiceResult<T>()
        {
            Data = default(T),
            Result = ResultType.Exception,
            Error = exceptionMessage,
        };
    }
}

public interface IFoodGroupService
{
    public Task<ServiceResult<FoodGroup>> ValidateExistedAsync(int id, bool isTracked = false);
}
public class FoodGroupService : IFoodGroupService
{
    private readonly IFoodGroupRepository _foodGroupRepository;
    public FoodGroupService(IFoodGroupRepository foodGroupRepository)
    {
        _foodGroupRepository = foodGroupRepository;
    }
    public async Task<ServiceResult<FoodGroup>> ValidateExistedAsync(int id, bool isTracked = false)
    {
        var existed = await _foodGroupRepository.GetAsync(id, isTracked);
        if (existed is null)
            return ServiceResult<FoodGroup>.Failure("Not found");
        return ServiceResult<FoodGroup>.Success(existed);
    }
}