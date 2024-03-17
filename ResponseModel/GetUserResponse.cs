using DevAlApplication.Models;
using DevAlApplication.Models.GeneralModels;

namespace DevAlApplication.ResponseModel
{
    public class GetUserResponse
    {
        public User GetUser { get; set; }
        public ErrorDetail ErrorDetail { get; set; }

        public GetUserResponse()
        {
            ErrorDetail = new ErrorDetail();
        }

        public GetUserResponse(User getUser)
        {
            GetUser = getUser;
            ErrorDetail = new ErrorDetail();
        }
    }
}
