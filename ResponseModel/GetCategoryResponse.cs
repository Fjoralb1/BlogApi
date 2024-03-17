using DevAlApplication.Models;
using DevAlApplication.Models.GeneralModels;

namespace DevAlApplication.ResponseModel
{
    public class GetCategoryResponse
    {
        public Category Category { get; set; }
        public ErrorDetail ErrorDetail { get; set; }

        public GetCategoryResponse()
        {
            ErrorDetail = new ErrorDetail();
        }

        public GetCategoryResponse(Category category)
        {
            Category = category;
            ErrorDetail = new ErrorDetail();
        }
    }
}
