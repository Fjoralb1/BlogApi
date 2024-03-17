using DevAlApplication.Interface;
using DevAlApplication.Models;
using DevAlApplication.Models.GeneralModels;
using DevAlApplication.ResponseModel;
using DevAlApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevAlApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ProcessLogs _logger;
        private readonly IUserService _userService;

        public UserController(IUserService userService, ILogger<ProcessLogs> logger)
        {
            _logger = new ProcessLogs(logger);
            _userService = userService;
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<ControllerResponse<GetUserResponse>> GetUser(Guid UserID)
        {
            using (_logger.BeginScope(nameof(this.GetUser)))
            {
                _logger.StartLog(nameof(this.GetUser));

                var response = await _userService.GetUser(UserID);

                if (response.ErrorDetail.ErrorMessage != null)
                {
                    return new ControllerResponse<GetUserResponse>()
                    {
                        Success = false,
                        ResponseObject = new GetUserResponse { },
                        ErrorDetail = new ErrorDetail()
                        {
                            ErrorCode = response.ErrorDetail.ErrorCode,
                            ErrorMessage = response.ErrorDetail.ErrorMessage
                        }
                    };
                }

                _logger.EndLog(nameof(this.GetUser));

                return new ControllerResponse<GetUserResponse>()
                {
                    ResponseObject = response
                }; 
            }
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<ControllerResponse<AddUserResponse>> AddUser(User user)
        {
            using (_logger.BeginScope(nameof(this.AddUser)))
            {
                _logger.StartLog(nameof(this.AddUser));

                var response = await _userService.AddUser(user);

                if (response.ErrorDetail.ErrorMessage != null)
                {
                    return new ControllerResponse<AddUserResponse>()
                    {
                        Success = false,
                        ResponseObject = new AddUserResponse { },
                        ErrorDetail = new ErrorDetail()
                        {
                            ErrorCode = response.ErrorDetail.ErrorCode,
                            ErrorMessage = response.ErrorDetail.ErrorMessage
                        }
                    };
                }

                _logger.EndLog(nameof(this.AddUser));

                return new ControllerResponse<AddUserResponse>()
                {
                    ResponseObject = response
                };
            }
        }
    }
}
