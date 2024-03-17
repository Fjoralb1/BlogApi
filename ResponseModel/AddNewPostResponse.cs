using DevAlApplication.Models;
using DevAlApplication.Models.GeneralModels;

namespace DevAlApplication.ResponseModel
{
    public class AddNewPostResponse
    {
        public Post Post { get; set; }
        public ErrorDetail ErrorDetail { get; set; }

        public AddNewPostResponse()
        {
            ErrorDetail = new ErrorDetail();
        }

        public AddNewPostResponse(Post post)
        {
            Post = post;
            ErrorDetail = new ErrorDetail();
        }
    }
}
