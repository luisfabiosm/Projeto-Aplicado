using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Adapters.Inbound.Configuration
{
    public class HttpExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<HttpExceptionFilter> _logger;

        public HttpExceptionFilter(ILogger<HttpExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            int code = StatusCodes.Status500InternalServerError;

            switch (context.Exception)
            {
                case PandaNotFoundException _:
                    {
                        code = (int)HttpStatusCode.NotFound;
                        break;
                    }
                default:
                    break;
            }
            _logger.LogWarning(context.Exception, "Handled exception thrown");

            context.Result = new ObjectResult(
                new
                {
                    context.Exception.Message,
                    Code = $"{code}"
                }
            );
            context.HttpContext.Response.StatusCode = code;

            context.ExceptionHandled = true;
        }
    }
}
