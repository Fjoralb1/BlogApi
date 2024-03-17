using DevAlApplication.Models;
using DevAlApplication.Models.GeneralModels;

namespace DevAlApplication.ResponseModel
{
    public class UpdateCategoryResponse
    {
        public Category Category { get; set; }
        public ErrorDetail ErrorDetail { get; set; }

        public UpdateCategoryResponse()
        {
            ErrorDetail = new ErrorDetail();
        }
        public UpdateCategoryResponse(Category category)
        {
            Category = category;
            ErrorDetail = new ErrorDetail();
        }
    }
}
