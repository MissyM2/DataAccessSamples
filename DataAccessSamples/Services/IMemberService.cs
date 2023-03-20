using System;
namespace DataAccessSamples.Services
{
	public interface IMemberService
    {
        Task<List<MemberModel>> GetMemberList();
        Task<int> AddMember(MemberModel MemberModel);
        Task<int> DeleteMember(MemberModel MemberModel);
        Task<int> UpdateMember(MemberModel MemberModel);
    }
}

