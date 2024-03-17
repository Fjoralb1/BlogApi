using DevAlApplication.Interface;
using DevAlApplication.Models;
using DevAlApplication.ResponseModel;

namespace DevAlApplication.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IGenericRepository<User> userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AddUserResponse> AddUser(User user)
        {
            try
            {
                await _userRepository.AddAsync(user);
                await _unitOfWork.SaveChangesAsync();
                return new AddUserResponse(user);
            }
            catch (Exception ex)
            {
                return new AddUserResponse
                {
                    ErrorDetail = new Models.GeneralModels.ErrorDetail()
                    {
                        ErrorMessage = ex.Message,
                        ErrorCode = ex.HResult
                    }
                };
            }
        }

        public async Task<GetUserResponse> GetUser(Guid UserID)
        {
            try
            {
                var response = await _userRepository.GetByIdAsync(UserID);
                return new GetUserResponse(response);
            }
            catch (Exception ex)
            {
                return new GetUserResponse
                {
                    ErrorDetail = new Models.GeneralModels.ErrorDetail
                    {
                        ErrorMessage = ex.Message,
                        ErrorCode = ex.HResult
                    }
                };
            }
        }
    }
}
