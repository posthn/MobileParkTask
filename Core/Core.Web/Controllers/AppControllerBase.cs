using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MobileParkTask.Core.Web;

[ApiController]
[Route("[controller]")]
public abstract class AppControllerBase : ControllerBase
{
    protected async Task<IActionResult> ProcessRequestAsync<TResult>(Func<Task<TResult>> process, int notOkCode = StatusCodes.Status404NotFound)
    {
        try
        {
            var result = await process();

            if (result is null)
                return StatusCode(notOkCode);

            return StatusCode(StatusCodes.Status200OK, result);
        }
        catch (ArgumentException ex)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status501NotImplemented, ex.Message);
        }
    }
}