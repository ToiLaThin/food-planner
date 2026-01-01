using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

[ApiController]
public class ExceptionController: ControllerBase
{
    [Route("exception")]
    public IActionResult Exception()
    {
        var feature = HttpContext.Features.GetRequiredFeature<IExceptionHandlerFeature>();
        var error = feature.Error;
        return Problem(
            title: "Unhandled Error",
            detail: error?.Message,
            statusCode: StatusCodes.Status500InternalServerError
        );
    }
}