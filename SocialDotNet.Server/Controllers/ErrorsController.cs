using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace SocialDotNet.Server.Controllers
{
    [Route("/error")]
    public class ErrorsController : ControllerBase
    {
        [HttpPost]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
              return Problem();
        }
    }
}