using DevAlApplication.Models;
using DevAlApplication.ResponseModel;

namespace DevAlApplication.Interface
{
    public interface IPostService
    {
        Task<AddNewPostResponse> AddNewPost(Post post);
        Task<GetAllPostsResponse> GetAllPosts();
        Task<GetAllPostsResponse> GetFilteredPosts(string Title, string Content, DateTime createdDate);
        Task<DeletePostResponse> DeletePost(Post post);
        Task<UpdatePostResponse> UpdatePost(Post post);
    }
}
