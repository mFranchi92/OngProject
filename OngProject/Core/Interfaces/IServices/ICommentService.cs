using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using OngProject.Core.DTOs;
using OngProject.Core.Entities;
using OngProject.Core.Helper;

namespace OngProject.Core.Interfaces.IServices
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDto>> GetComments();

        Task<Comment> GetComment(int id);

        Task<GenericResult> InsertComment(CommentInsertDto comment, ClaimsPrincipal user);

        Task<GenericResult> UpdateComment(int id, CommentUpdateDto commentDto);

        Task<bool> DeleteComment(int id);
        Task<bool> ValidateCreatorOrAdminAsync(ClaimsPrincipal user, int commentId);
        bool EntityExists(int id);
    }
}