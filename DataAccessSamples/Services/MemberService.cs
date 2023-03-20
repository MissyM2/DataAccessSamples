using System;
using DataAccessSamples.Data;
using SQLite;

namespace DataAccessSamples.Services
{
    public class MemberService : IMemberService
    {

        private SQLiteAsyncConnection _dbConnection;

        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MemberDb.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<MemberModel>();
                AddTestData();
            }
        }



        void AddTestData()
        {
            var item1 = new MemberModel{
                FirstName = "Joanne",
                LastName = "Lyons",
                Email = "Babe@lyons.com",
                Address1 = "102 Herndon Pkwy",
                Address2 = "",
                City = "Herndon",
                State = "VA",
                Zip = "10128",
                Subscribed = true
            };
            var item2 = new MemberModel
            {
                FirstName = "John",
                LastName = "Lyons",
                Email = "john@lyons.com",
                Address1 = "102 Herndon Pkwy",
                Address2 = "",
                City = "Herndon",
                State = "VA",
                Zip = "10128",
                Subscribed = true
            };

            _dbConnection.InsertAsync(item1);
            _dbConnection.InsertAsync(item2);
        }

        public async Task<int> AddMember(MemberModel MemberModel)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(MemberModel);
        }

        public async Task<int> DeleteMember(MemberModel MemberModel)
        {
            await SetUpDb();
            return await _dbConnection.DeleteAsync(MemberModel);
        }

        public async Task<List<MemberModel>> GetMemberList()
        {
            await SetUpDb();
            var MemberList = await _dbConnection.Table<MemberModel>().ToListAsync();
            return MemberList;
        }

        public async Task<int> UpdateMember(MemberModel MemberModel)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(MemberModel);
        }
    }
}

