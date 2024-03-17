using DevAlApplication.Models;
using DevAlApplication.Models.GeneralModels;

namespace DevAlApplication.ResponseModel
{
    public class GetAllPostsResponse
    {
        public List<Post> Posts { get; set; }
        public ErrorDetail ErrorDetail { get; set; }

        public GetAllPostsResponse()
        {
            ErrorDetail = new ErrorDetail();
        }

        public GetAllPostsResponse(List<Post> posts)
        {
            Posts = posts;
            ErrorDetail = new ErrorDetail();
        }
    }
}
