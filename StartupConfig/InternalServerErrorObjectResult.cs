using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevAlApplication.StartupConfig
{
    public class InternalServerErrorObjectResult : ObjectResult
    {
        public InternalServerErrorObjectResult(object error) : base(error)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
