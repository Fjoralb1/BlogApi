using DevAlApplication.Models;
using DevAlApplication.ResponseModel;

namespace DevAlApplication.Interface
{
    public interface ICategoryService
    {
        Task<AddCategoryResponse> AddCategory(Category category);
        Task<GetCategoryListResponse> GetAllCategories();
        Task<UpdateCategoryResponse> UpdateCategory(Category category);
        Task<DeleteCategoryResponse> DeleteCategory(Category category);
        Task<GetCategoryResponse> GetCategory(Guid id);
    }
}
