using System;
using DataAccessSamples.Data;
using SQLite;

namespace DataAccessSamples.Services
{
    public class MemberService : IMemberService
    {

        SQLiteAsyncConnection _dbConnection;

        List<MemberModel> memberList;

        private async Task Init()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(FileSystem.AppDataDirectory, "MemberDb.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<MemberModel>();
                //var item1 = new MemberModel
                //{
                //    FirstName = "Joanne",
                //    LastName = "Lyons",
                //    Email = "Babe@lyons.com",
                //    Address1 = "102 Herndon Pkwy",
                //    Address2 = "",
                //    City = "Herndon",
                //    State = "VA",
                //    Zip = "10128",
                //    Subscribed = true
                //};
                //var item2 = new MemberModel
                //{
                //    FirstName = "John",
                //    LastName = "Lyons",
                //    Email = "john@lyons.com",
                //    Address1 = "102 Herndon Pkwy",
                //    Address2 = "",
                //    City = "Herndon",
                //    State = "VA",
                //    Zip = "10128",
                //    Subscribed = true
                //};

                //await _dbConnection.InsertAsync(item1);
                //await _dbConnection.InsertAsync(item2);
            }
        }



        public async Task<List<MemberModel>> GetMemberList()
        {
            await Init();
            memberList = await _dbConnection.Table<MemberModel>().ToListAsync();
            return memberList;

        }

        //public async Task<MemberModel> GetMember(int id)
        //{
        //    try
        //    {
        //        Init();
        //        return await _dbConnection.Table<MemberModel>().FirstOrDefaultAsync(q => q.Id == id);
        //    }
        //    catch (Exception)
        //    {
        //        StatusMessage = "Failed to retrieve data.";
        //    }

        //    return null;
        //}

        public async Task<int> AddMember(MemberModel memberModel)
        {
            await Init();
            return await _dbConnection.InsertAsync(memberModel);

        }

        public async Task<int> DeleteMember(MemberModel memberModel)
        {
            await Init();
            return await _dbConnection.DeleteAsync(memberModel);
        }

        public async Task<int> UpdateMember(MemberModel memberModel)
        {
            await Init();
            return await _dbConnection.UpdateAsync(memberModel);
        }
    }
}

