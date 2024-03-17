using DevAlApplication.Models;
using DevAlApplication.Models.GeneralModels;

namespace DevAlApplication.ResponseModel
{
    public class DeletePostResponse
    {
        public Post Post { get; set; }
        public ErrorDetail ErrorDetail { get; set; }

        public DeletePostResponse()
        {
            ErrorDetail = new ErrorDetail();
        }

        public DeletePostResponse(Post post)
        {
            Post = post;
            ErrorDetail = new ErrorDetail();
        }
    }
}
