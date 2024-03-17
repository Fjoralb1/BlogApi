using DevAlApplication.Models;
using DevAlApplication.Models.GeneralModels;

namespace DevAlApplication.ResponseModel
{
    public class AddCategoryResponse
    {
        public Category Category { get; set; }
        public ErrorDetail ErrorDetail { get; set; }

        public AddCategoryResponse() 
        {
            ErrorDetail = new ErrorDetail();
        }

        public AddCategoryResponse(Category category)
        {
            Category = category;
            ErrorDetail = new ErrorDetail();
        }
    }
}
