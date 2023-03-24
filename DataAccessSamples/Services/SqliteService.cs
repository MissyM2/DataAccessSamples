using System;
using SQLite;
using DataAccessSamples.Models;

namespace DataAccessSamples.Services
{
    public partial class SqliteService : ISqliteService
    {
        SQLiteAsyncConnection _dbConnection;

        List<MemberModel> memberModel;

        public SqliteService()
        {
            if (File.Exists(Constants.DatabasePath))
                Console.WriteLine("Database exists");
            else
                CreateDatabase();
        }

        void Init()
        {
            if (_dbConnection == null)
                _dbConnection = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        async void CreateDatabase()
        {
            _dbConnection = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await _dbConnection.CreateTableAsync<MemberModel>();

            AddTestData();
        }

        void AddTestData()
        {
            var item1 = new MemberModel
            {
                FirstName = "Joanne",
                LastName = "Lyons",
                Email = "Babe@lyons.com",
                Address1 = "102 Herndon Pkwy",
                Address2 = "",
                City = "Herndon",
                State = "VA",
                Zip = "10128",
                Subscribed = true,
                HairColor = "Brown",
                Height = "5' 4'",
                FavoriteColor = "Pink",
                FavoriteHobby = "Ice Skating",
                MothersName = "Janet",
                FathersName = " Joseph"
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
                Subscribed = true,
                HairColor = "Brown",
                Height = "5' 4'",
                FavoriteColor = "Pink",
                FavoriteHobby = "Ice Skating",
                MothersName = "Janet",
                FathersName = " Joseph"
            };
            var item3 = new MemberModel
            {
                FirstName = "Ginger",
                LastName = "Lyons",
                Email = "Ginger@lyons.com",
                Address1 = "102 Herndon Pkwy",
                Address2 = "",
                City = "Herndon",
                State = "VA",
                Zip = "10128",
                Subscribed = true,
                HairColor = "Brown",
                Height = "5' 4'",
                FavoriteColor = "Pink",
                FavoriteHobby = "Ice Skating",
                MothersName = "Janet",
                FathersName = " Joseph"
            };
            var item4 = new MemberModel
            {
                FirstName = "Daniel",
                LastName = "Lyons",
                Email = "daniel@lyons.com",
                Address1 = "10 Oak Pkwy",
                Address2 = "",
                City = "Oakton",
                State = "VA",
                Zip = "10128",
                Subscribed = true,
                HairColor = "Brown",
                Height = "5' 4'",
                FavoriteColor = "Pink",
                FavoriteHobby = "Ice Skating",
                MothersName = "Janet",
                FathersName = " Joseph"
            };
            var item5 = new MemberModel
            {
                FirstName = "Michell",
                LastName = "Lyons",
                Email = "Michelle@lyons.com",
                Address1 = "102 Smith Pkwy",
                Address2 = "",
                City = "Fairfax",
                State = "VA",
                Zip = "10128",
                Subscribed = true,
                HairColor = "Brown",
                Height = "5' 4'",
                FavoriteColor = "Pink",
                FavoriteHobby = "Ice Skating",
                MothersName = "Janet",
                FathersName = " Joseph"
            };
            var item6 = new MemberModel
            {
                FirstName = "Missy",
                LastName = "Maloney",
                Email = "missy@maloney.com",
                Address1 = "4 Hitching Pkwy",
                Address2 = "",
                City = "Bethesda",
                State = "MD",
                Zip = "10128",
                Subscribed = true,
                HairColor = "Brown",
                Height = "5' 4'",
                FavoriteColor = "Pink",
                FavoriteHobby = "Ice Skating",
                MothersName = "Janet",
                FathersName = " Joseph"
            };

            var item7 = new MemberModel
            {
                FirstName = "Becky",
                LastName = "Mancuso",
                Email = "becky@mancuso.com",
                Address1 = "4 Hitching Pkwy",
                Address2 = "",
                City = "Bethesda",
                State = "CO",
                Zip = "10128",
                Subscribed = true,
                HairColor = "Blonde",
                Height = "5' 4'",
                FavoriteColor = "Orange",
                FavoriteHobby = "gardening",
                MothersName = "Janet",
                FathersName = "David"
            };

            var item8 = new MemberModel
            {
                FirstName = "Maddy",
                LastName = "Smith",
                Email = "maddie@smith.com",
                Address1 = "4 Hitching Pkwy",
                Address2 = "",
                City = "Bethesda",
                State = "MD",
                Zip = "10128",
                Subscribed = true,
                HairColor = "Blonde",
                Height = "5' 4'",
                FavoriteColor = "Green",
                FavoriteHobby = "Reading",
                MothersName = "Marion",
                FathersName = "Jones"
            };

            var item9 = new MemberModel
            {
                FirstName = "Gabrielle",
                LastName = "Dittmer",
                Email = "Gabrielle@Dittmer.com",
                Address1 = "4 Hitching Pkwy",
                Address2 = "",
                City = "Bethesda",
                State = "VA",
                Zip = "10128",
                Subscribed = true,
                HairColor = "Light Brown",
                Height = "5' 4'",
                FavoriteColor = "Red",
                FavoriteHobby = "Lawyering",
                MothersName = "Anne",
                FathersName = " James"
            };

            var item10 = new MemberModel
            {
                FirstName = "Hannah",
                LastName = "Whistler",
                Email = "hannah@whistler.com",
                Address1 = "4 Hitching Pkwy",
                Address2 = "",
                City = "Virginia Beach",
                State = "VA",
                Zip = "10128",
                Subscribed = true,
                HairColor = "Brown",
                Height = "5' 4'",
                FavoriteColor = "Pink",
                FavoriteHobby = "Crafting",
                MothersName = "Tamara",
                FathersName = " greg"
            };

            var item11 = new MemberModel
            {
                FirstName = "Emily",
                LastName = "Devine",
                Email = "emily@devine.com",
                Address1 = "4 Hitching Pkwy",
                Address2 = "",
                City = "Gaithersburg",
                State = "MD",
                Zip = "10128",
                Subscribed = true,
                HairColor = "Brown",
                Height = "5' 4'",
                FavoriteColor = "Pink",
                FavoriteHobby = "Swimming",
                MothersName = "Ophelia",
                FathersName = " Cooper"
            };
            _dbConnection.InsertAsync(item1);
            _dbConnection.InsertAsync(item2);
            _dbConnection.InsertAsync(item3);
            _dbConnection.InsertAsync(item4);
            _dbConnection.InsertAsync(item5);
            _dbConnection.InsertAsync(item6);
            _dbConnection.InsertAsync(item7);
            _dbConnection.InsertAsync(item8);
            _dbConnection.InsertAsync(item9);
            _dbConnection.InsertAsync(item10);
            _dbConnection.InsertAsync(item11);
        }

        public async Task<List<MemberModel>> GetListAsync()
        {
            Init();
            return await _dbConnection.Table<MemberModel>().ToListAsync();
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

        public async Task<int> Add(MemberModel memberModel)
        {
            Init();
            return await _dbConnection.InsertAsync(memberModel);

        }

        public async Task<int> Delete(MemberModel memberModel)
        {
            Init();
            return await _dbConnection.DeleteAsync(memberModel);
        }

        public async Task<int> Update(MemberModel memberModel)
        {
            Init();
            return await _dbConnection.UpdateAsync(memberModel);
        }
    }
}

