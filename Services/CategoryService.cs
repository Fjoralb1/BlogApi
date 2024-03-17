using DevAlApplication.Interface;
using DevAlApplication.Models;
using DevAlApplication.ResponseModel;
using Microsoft.AspNetCore.Authorization;

namespace DevAlApplication.Services
{
    [Authorize]
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IGenericRepository<Category> categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AddCategoryResponse> AddCategory(Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.SaveChangesAsync();
                return new AddCategoryResponse(category);
            }
            catch (Exception ex)
            {
                return new AddCategoryResponse
                {
                    ErrorDetail = new Models.GeneralModels.ErrorDetail
                    {
                        ErrorMessage = ex.Message,
                        ErrorCode = ex.HResult
                    }
                };
            }
        }

        public async Task<DeleteCategoryResponse> DeleteCategory(Category category)
        {
            try
            {
                if (!IsCategoryAssociatedWithPosts(category.Id))
                    await _categoryRepository.DeleteAsync(category);
                else
                    throw new Exception("Cannot delete Category related to a Post!");

                return new DeleteCategoryResponse(category);
            }
            catch (Exception ex)
            {
                return new DeleteCategoryResponse
                {
                    ErrorDetail = new Models.GeneralModels.ErrorDetail
                    {
                        ErrorMessage = ex.Message,
                        ErrorCode = ex.HResult
                    }
                };
            }
        }

        private bool IsCategoryAssociatedWithPosts(Guid categoryId)
        {
            return _categoryRepository.GetDbContext().Set<Post>().Any(x => x.Categories.Any(c => c.Id == categoryId));
        }

        public async Task<GetCategoryListResponse> GetAllCategories()
        {
            try
            {
                var result = await _categoryRepository.GetAllAsync();
                return new GetCategoryListResponse(result.ToList());
            }
            catch (Exception ex)
            {
                return new GetCategoryListResponse
                {
                    ErrorDetail = new Models.GeneralModels.ErrorDetail
                    {
                        ErrorMessage = ex.Message,
                        ErrorCode = ex.HResult
                    }
                };
            }
        }

        public async Task<GetCategoryResponse> GetCategory(Guid id)
        {
            try
            {
                var result = await _categoryRepository.GetByIdAsync(id);
                return new GetCategoryResponse(result);
            }
            catch (Exception ex)
            {
                return new GetCategoryResponse
                {
                    ErrorDetail = new Models.GeneralModels.ErrorDetail
                    {
                        ErrorMessage = ex.Message,
                        ErrorCode = ex.HResult
                    }
                };
            }
        }

        public async Task<UpdateCategoryResponse> UpdateCategory(Category category)
        {
            try
            {
                await _categoryRepository.UpdateAsync(category);
                return new UpdateCategoryResponse(category);
            }
            catch (Exception ex)
            {
                return new UpdateCategoryResponse
                {
                    ErrorDetail = new Models.GeneralModels.ErrorDetail
                    {
                        ErrorMessage = ex.Message,
                        ErrorCode = ex.HResult
                    }
                };
            }
        }
    }
}
