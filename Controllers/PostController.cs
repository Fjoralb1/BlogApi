using DevAlApplication.Interface;
using DevAlApplication.Models;
using DevAlApplication.Models.GeneralModels;
using DevAlApplication.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevAlApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly ProcessLogs _logger;
        private readonly IPostService _postService;

        public PostController(IPostService postService, ILogger<ProcessLogs> logger)
        {
            _logger = new ProcessLogs(logger);
            _postService = postService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("AddNewPost")]
        public async Task<ControllerResponse<AddNewPostResponse>> AddNewPost(Post post)
        {
            using (_logger.BeginScope(nameof(this.AddNewPost)))
            {
                _logger.StartLog(nameof(this.AddNewPost));

                var response = await _postService.AddNewPost(post);

                if (response.ErrorDetail.ErrorMessage != null)
                {
                    return new ControllerResponse<AddNewPostResponse>()
                    {
                        Success = false,
                        ResponseObject = new AddNewPostResponse(),
                        ErrorDetail = new ErrorDetail()
                        {
                            ErrorCode = response.ErrorDetail.ErrorCode,
                            ErrorMessage = response.ErrorDetail.ErrorMessage
                        }
                    };
                }

                _logger.EndLog(nameof(this.AddNewPost));

                return new ControllerResponse<AddNewPostResponse>()
                {
                    ResponseObject = response
                };
            }
        }

        [HttpGet]
        [Route("GetAllPosts")]
        public async Task<ControllerResponse<GetAllPostsResponse>> GetAllPosts()
        {
            using (_logger.BeginScope(nameof(this.GetAllPosts)))
            {
                _logger.StartLog(nameof(this.GetAllPosts));

                var response = await _postService.GetAllPosts();

                if (response.ErrorDetail.ErrorMessage != null)
                {
                    return new ControllerResponse<GetAllPostsResponse>()
                    {
                        Success = false,
                        ResponseObject = new GetAllPostsResponse(),
                        ErrorDetail = new ErrorDetail()
                        {
                            ErrorCode = response.ErrorDetail.ErrorCode,
                            ErrorMessage = response.ErrorDetail.ErrorMessage
                        }
                    };
                }

                _logger.EndLog(nameof(this.GetAllPosts));

                return new ControllerResponse<GetAllPostsResponse>()
                {
                    ResponseObject = response
                };
            }
        }

        [HttpGet]
        [Route("GetFilteredPosts")]
        public async Task<ControllerResponse<GetAllPostsResponse>> GetFilteredPosts(string Title, string Content, DateTime CreateDate)
        {
            using (_logger.BeginScope(nameof(this.GetFilteredPosts)))
            {
                _logger.StartLog(nameof(this.GetFilteredPosts));

                var response = await _postService.GetFilteredPosts(Title, Content, CreateDate);

                if (response.ErrorDetail.ErrorMessage != null)
                {
                    return new ControllerResponse<GetAllPostsResponse>()
                    {
                        Success = false,
                        ResponseObject = new GetAllPostsResponse(),
                        ErrorDetail = new ErrorDetail()
                        {
                            ErrorCode = response.ErrorDetail.ErrorCode,
                            ErrorMessage = response.ErrorDetail.ErrorMessage
                        }
                    };
                }

                _logger.EndLog(nameof(this.GetFilteredPosts));

                return new ControllerResponse<GetAllPostsResponse>()
                {
                    ResponseObject = response
                };
            }
        }

        [HttpDelete]
        [Route("DeletePost")]
        public async Task<ControllerResponse<DeletePostResponse>> DeletePost(Post post)
        {
            using (_logger.BeginScope(nameof(this.DeletePost)))
            {
                _logger.StartLog(nameof(this.DeletePost));

                var response = await _postService.DeletePost(post);

                if (response.ErrorDetail.ErrorMessage != null)
                {
                    return new ControllerResponse<DeletePostResponse>()
                    {
                        Success = false,
                        ResponseObject = new DeletePostResponse(),
                        ErrorDetail = new ErrorDetail()
                        {
                            ErrorCode = response.ErrorDetail.ErrorCode,
                            ErrorMessage = response.ErrorDetail.ErrorMessage
                        }
                    };
                }

                _logger.EndLog(nameof(this.DeletePost));

                return new ControllerResponse<DeletePostResponse>()
                {
                    ResponseObject = response
                };
            }
        }

        [HttpPost]
        [Route("UpdatePost")]
        public async Task<ControllerResponse<UpdatePostResponse>> UpdatePost(Post post)
        {
            using (_logger.BeginScope(nameof(this.UpdatePost)))
            {
                _logger.StartLog(nameof(this.UpdatePost));

                var response = await _postService.UpdatePost(post);

                if (response.ErrorDetail.ErrorMessage != null)
                {
                    return new ControllerResponse<UpdatePostResponse>()
                    {
                        Success = false,
                        ResponseObject = new UpdatePostResponse(),
                        ErrorDetail = new ErrorDetail()
                        {
                            ErrorCode = response.ErrorDetail.ErrorCode,
                            ErrorMessage = response.ErrorDetail.ErrorMessage
                        }
                    };
                }

                _logger.EndLog(nameof(this.UpdatePost));

                return new ControllerResponse<UpdatePostResponse>()
                {
                    ResponseObject = response
                };
            }
        }
    }
}
