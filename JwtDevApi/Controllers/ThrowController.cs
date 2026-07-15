using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtDevApi.Controllers
{
    // pra não aparecer no swagger
    [ApiExplorerSettings(IgnoreApi = true)]     // pra não aparecer no swagger
    public class ThrowController : ControllerBase
    {
        [Route("/error")]
        public IActionResult HandleError() => Problem();

        [Route("/error-development")]
        public IActionResult HandleErrorDevelopment(
            [FromServices] IHostEnvironment hostEnvironment)
        {
            if(!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }
            var exceptionHandlerFeature = 
                HttpContext.Features.Get<IExceptionHandlerFeature>()!;
            return Problem(
                detail: exceptionHandlerFeature.Error.StackTrace,
                title: exceptionHandlerFeature.Error.Message);
        }
    }
}
