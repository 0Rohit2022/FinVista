using api.DTOs.Comment;
using api.Models;

namespace api.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int Id);
        Task<Comment> CreateAsync(Comment commentModel);
        Task<Comment> DeleteAsync(int Id);
        Task<Comment?> UpdateAsync(int Id, CommentUpdateRequest updateRequest);
    }
}