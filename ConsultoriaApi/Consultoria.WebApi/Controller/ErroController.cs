using Consultoria.Core.Shared.ModelViews;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Consultoria.WebApi.Controller
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class ErroController : ControllerBase
    {
        [Route("error")]
        public ErrorResponse Error()
        {
            var contexto = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = contexto?.Error;

            Response.StatusCode = 500;

            var requestId = HttpContext?.TraceIdentifier;
            var idErro = Activity.Current?.Id ?? requestId;

            return new ErrorResponse(idErro, requestId);
        }
    }
}
