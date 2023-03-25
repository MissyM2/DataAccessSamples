namespace DataAccessSamples.Services
{
    public interface ISqliteService
    {
        void CheckDatabase();

        void GetDbConnection();

        Task CreateDatabase();

        Task<List<MemberModel>> GetListAsync();


        //Task<MemberModel> GetMember(int id)

        Task<int> AddItem(MemberModel memberModel);


        Task<int> DeleteItem(MemberModel memberModel);

        Task<int> UpdateItem(MemberModel memberModel);
     
    }
}