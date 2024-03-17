using DevAlApplication.Models;
using DevAlApplication.Models.GeneralModels;

namespace DevAlApplication.ResponseModel
{
    public class GetCategoryListResponse
    {
        public List<Category> Categories { get; set; }
        public ErrorDetail ErrorDetail { get; set; }

        public GetCategoryListResponse() 
        {
            ErrorDetail = new ErrorDetail();
        }
        public GetCategoryListResponse(List<Category> categories)
        {
            Categories = categories;
            ErrorDetail = new ErrorDetail();
        }
    }
}
