using System;
namespace DataAccessSamples.Services
{
    public interface IMemberService
    {
        Task<List<MemberModel>> GetMemberList();
        Task<int> AddMember(MemberModel memberModel);
        Task<int> DeleteMember(MemberModel memberModel);
        Task<int> UpdateMember(MemberModel memberModel);
    }
}

