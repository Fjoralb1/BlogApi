using DevAlApplication.Models;
using DevAlApplication.ResponseModel;

namespace DevAlApplication.Interface
{
    public interface IUserService
    {
        Task<AddUserResponse> AddUser(User user);
        Task<GetUserResponse> GetUser(Guid UserID);
    }
}
