using DevAlApplication.Models.GeneralModels;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DevAlApplication.StartupConfig
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {

        private readonly IWebHostEnvironment _env;
        private readonly ILogger<HttpGlobalExceptionFilter> _logger;

        public HttpGlobalExceptionFilter(IWebHostEnvironment env, ILogger<HttpGlobalExceptionFilter> logger)
        {
            _env = env;
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(new EventId(context.Exception.HResult), context.Exception, context.Exception.Message);

            var jsonResult = new ControllerResponse<object>(false, context.Exception.Message);


            if (context.Exception.GetType() == typeof(UnauthorizedAccessException))
            {
                context.Result = new UnauthorizedResult();
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            else
            {
                context.Result = new InternalServerErrorObjectResult(jsonResult);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
        }
    }
}
