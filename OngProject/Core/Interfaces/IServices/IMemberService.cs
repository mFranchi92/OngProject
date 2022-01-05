using System.Collections.Generic;
using System.Threading.Tasks;
using OngProject.Core.DTOs;
using OngProject.Core.Entities;
using OngProject.Core.Helper.Pagination;

namespace OngProject.Core.Interfaces.IServices
{
    public interface IMemberService
    {
        Task<ResponsePagination<GenericPagination<Member>>> GetMembers(int page, int pageSize, string controller);

        Task<Member> GetMember(int id);

        Task InsertMember(MemberDto memberDto);

        Task<bool> UpdateMember(int id ,MemberEditDto memberDto);

        Task<bool> DeleteMember(int id);
        bool EntityExists(int id);
    }
}