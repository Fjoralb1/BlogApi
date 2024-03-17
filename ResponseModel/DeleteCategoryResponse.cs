using DevAlApplication.Models;
using DevAlApplication.Models.GeneralModels;

namespace DevAlApplication.ResponseModel
{
    public class DeleteCategoryResponse
    {
        public Category Category { get; set; }
        public ErrorDetail ErrorDetail { get; set; }

        public DeleteCategoryResponse() 
        {
            ErrorDetail = new ErrorDetail();
        }

        public DeleteCategoryResponse(Category category)
        {
            Category = category;
            ErrorDetail = new ErrorDetail();
        }
    }
}
