using DevAlApplication.Models;
using DevAlApplication.Models.GeneralModels;

namespace DevAlApplication.ResponseModel
{
    public class AddUserResponse
    {
        public User User { get; set; }
        public ErrorDetail ErrorDetail { get; set; }

        public AddUserResponse()
        {
            ErrorDetail = new ErrorDetail();
        }

        public AddUserResponse(User user)
        {
            User = user;
            ErrorDetail = new ErrorDetail();
        }
    }
}
