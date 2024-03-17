using DevAlApplication.Interface;
using DevAlApplication.Models;
using DevAlApplication.ResponseModel;
using System.Security.Claims;

namespace DevAlApplication.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Post> _postRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PostService(IGenericRepository<Post> postRepository, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _postRepository = postRepository;
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
        }

        public async Task<AddNewPostResponse> AddNewPost(Post post)
        {
            try
            {
                var userID = Guid.Parse(_httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                post.CreatedBy = userID;
                await _postRepository.AddAsync(post);
                await _unitOfWork.SaveChangesAsync();
                return new AddNewPostResponse(post);
            }
            catch (Exception ex)
            {
                return new AddNewPostResponse
                {
                    ErrorDetail = new Models.GeneralModels.ErrorDetail
                    {
                        ErrorMessage = ex.Message,
                        ErrorCode = ex.HResult
                    }
                };
            }
        }

        public async Task<DeletePostResponse> DeletePost(Post post)
        {
            try
            {
                var userID = Guid.Parse(_httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                if (userID != post.CreatedBy)
                {
                    throw new Exception("You are not authorized to delete this post.");
                }
                await _postRepository.DeleteAsync(post);
                await _unitOfWork.SaveChangesAsync();
                return new DeletePostResponse(post);
            }
            catch (Exception ex)
            {
                return new DeletePostResponse
                {
                    ErrorDetail = new Models.GeneralModels.ErrorDetail
                    {
                        ErrorMessage = ex.Message,
                        ErrorCode = ex.HResult
                    }
                };
            }
        }

        public async Task<GetAllPostsResponse> GetAllPosts()
        {
            try
            {
                var result = await _postRepository.GetAllAsync();
                return new GetAllPostsResponse(result.ToList());
            }
            catch (Exception ex)
            {
                return new GetAllPostsResponse
                {
                    ErrorDetail = new Models.GeneralModels.ErrorDetail
                    {
                        ErrorMessage = ex.Message,
                        ErrorCode = ex.HResult
                    }
                };
            }
        }

        public async Task<GetAllPostsResponse> GetFilteredPosts(string Title, string Content, DateTime createdDate)
        {
            try
            {
                var result = await _postRepository.FindAsync(x => x.Title == Title || x.Content.Contains(Content) || x.CreationDate.Date == createdDate.Date);
                return new GetAllPostsResponse(result.ToList());
            }
            catch (Exception ex)
            {
                return new GetAllPostsResponse
                {
                    ErrorDetail = new Models.GeneralModels.ErrorDetail
                    {
                        ErrorMessage = ex.Message,
                        ErrorCode = ex.HResult
                    }
                };
            }
        }

        public async Task<UpdatePostResponse> UpdatePost(Post post)
        {
            try
            {
                var userID = Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

                if (userID != post.CreatedBy)
                {
                    throw new Exception("You are not authorized to edit this post.");
                }

                await _postRepository.UpdateAsync(post);
                await _unitOfWork.SaveChangesAsync();
                return new UpdatePostResponse(post);
            }
            catch (Exception ex)
            {
                return new UpdatePostResponse
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
