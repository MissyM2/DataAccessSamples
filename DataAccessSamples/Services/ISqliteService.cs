using System;
namespace DataAccessSamples.Services
{
    public interface ISqliteService
    {
        Task<List<MemberModel>> GetListAsync();
        Task<int> Add(MemberModel memberModel);
        Task<int> Delete(MemberModel memberModel);
        Task<int> Update(MemberModel memberModel);
    }
}

