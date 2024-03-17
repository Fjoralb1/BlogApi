using DevAlApplication.Interface;
using DevAlApplication.Models;
using DevAlApplication.Models.GeneralModels;
using DevAlApplication.ResponseModel;
using DevAlApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevAlApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ProcessLogs _logger;
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService, ILogger<ProcessLogs> logger) 
        {
            _logger = new ProcessLogs(logger);
            _categoryService = categoryService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("AddCategory")]
        public async Task<ControllerResponse<AddCategoryResponse>> AddCategory(Category category)
        {
            using (_logger.BeginScope(nameof(this.AddCategory)))
            {
                _logger.StartLog(nameof(this.AddCategory));

                var response = await _categoryService.AddCategory(category);

                if (response.ErrorDetail.ErrorMessage != null)
                {
                    return new ControllerResponse<AddCategoryResponse>()
                    {
                        Success = false,
                        ResponseObject = new AddCategoryResponse(),
                        ErrorDetail = new ErrorDetail()
                        {
                            ErrorCode = response.ErrorDetail.ErrorCode,
                            ErrorMessage = response.ErrorDetail.ErrorMessage
                        }
                    };
                }

                _logger.EndLog(nameof(this.AddCategory));

                return new ControllerResponse<AddCategoryResponse>()
                {
                    ResponseObject = response
                };
            }
        }

        [HttpGet]
        [Route("GetAllCategories")]
        public async Task<ControllerResponse<GetCategoryListResponse>> GetAllCategories()
        {
            using (_logger.BeginScope(nameof(this.GetAllCategories)))
            {
                _logger.StartLog(nameof(this.GetAllCategories));

                var response = await _categoryService.GetAllCategories();

                if (response.ErrorDetail.ErrorMessage != null)
                {
                    return new ControllerResponse<GetCategoryListResponse>()
                    {
                        Success = false,
                        ResponseObject = new GetCategoryListResponse(),
                        ErrorDetail = new ErrorDetail()
                        {
                            ErrorCode = response.ErrorDetail.ErrorCode,
                            ErrorMessage = response.ErrorDetail.ErrorMessage
                        }
                    };
                }

                _logger.EndLog(nameof(this.GetAllCategories));

                return new ControllerResponse<GetCategoryListResponse>()
                {
                    ResponseObject = response
                };
            }
        }

        [HttpGet]
        [Route("GetCategory")]
        public async Task<ControllerResponse<GetCategoryResponse>> GetCategory(Guid Id)
        {
            using (_logger.BeginScope(nameof(this.GetCategory)))
            {
                _logger.StartLog(nameof(this.GetCategory));

                var response = await _categoryService.GetCategory(Id);

                if (response.ErrorDetail.ErrorMessage != null)
                {
                    return new ControllerResponse<GetCategoryResponse>()
                    {
                        Success = false,
                        ResponseObject = new GetCategoryResponse(),
                        ErrorDetail = new ErrorDetail()
                        {
                            ErrorCode = response.ErrorDetail.ErrorCode,
                            ErrorMessage = response.ErrorDetail.ErrorMessage
                        }
                    };
                }

                _logger.EndLog(nameof(this.GetCategory));

                return new ControllerResponse<GetCategoryResponse>()
                {
                    ResponseObject = response
                };
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("UpdateCategory")]
        public async Task<ControllerResponse<UpdateCategoryResponse>> UpdateCategory(Category category)
        {
            using (_logger.BeginScope(nameof(this.UpdateCategory)))
            {
                _logger.StartLog(nameof(this.UpdateCategory));

                var response = await _categoryService.UpdateCategory(category);

                if (response.ErrorDetail.ErrorMessage != null)
                {
                    return new ControllerResponse<UpdateCategoryResponse>()
                    {
                        Success = false,
                        ResponseObject = new UpdateCategoryResponse(),
                        ErrorDetail = new ErrorDetail()
                        {
                            ErrorCode = response.ErrorDetail.ErrorCode,
                            ErrorMessage = response.ErrorDetail.ErrorMessage
                        }
                    };
                }

                _logger.EndLog(nameof(this.UpdateCategory));

                return new ControllerResponse<UpdateCategoryResponse>()
                {
                    ResponseObject = response
                };
            }
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("DeleteCategory")]
        public async Task<ControllerResponse<DeleteCategoryResponse>> DeleteCategory(Category category)
        {
            using (_logger.BeginScope(nameof(this.DeleteCategory)))
            {
                _logger.StartLog(nameof(this.DeleteCategory));

                var response = await _categoryService.DeleteCategory(category);

                if (response.ErrorDetail.ErrorMessage != null)
                {
                    return new ControllerResponse<DeleteCategoryResponse>()
                    {
                        Success = false,
                        ResponseObject = new DeleteCategoryResponse(),
                        ErrorDetail = new ErrorDetail()
                        {
                            ErrorCode = response.ErrorDetail.ErrorCode,
                            ErrorMessage = response.ErrorDetail.ErrorMessage
                        }
                    };
                }

                _logger.EndLog(nameof(this.UpdateCategory));

                return new ControllerResponse<DeleteCategoryResponse>()
                {
                    ResponseObject = response
                };
            }
        }
    }
}
