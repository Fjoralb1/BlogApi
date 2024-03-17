using DevAlApplication.Models;
using DevAlApplication.Models.GeneralModels;

namespace DevAlApplication.ResponseModel
{
    public class UpdatePostResponse
    {
        public Post Post { get; set; }
        public ErrorDetail ErrorDetail { get; set; }

        public UpdatePostResponse()
        {
            ErrorDetail = new ErrorDetail();
        }

        public UpdatePostResponse(Post post)
        {
            Post = post;
            ErrorDetail = new ErrorDetail();
        }
    }
}
