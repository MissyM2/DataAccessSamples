using System;
namespace DataAccessSamples.ViewModels
{
    [QueryProperty(nameof(MemberDetail), "MemberDetail")]

    public partial class AddUpdateMemberDetailVM : BaseVM
    {
        [ObservableProperty]
        private MemberModel _memberDetail = new MemberModel();

        private readonly ISqliteService sqliteService;

        public AddUpdateMemberDetailVM(ISqliteService sqliteService)
        {
            this.sqliteService = sqliteService;
        }

        [RelayCommand]
        public async void AddUpdateMember()
        {
            int response = -1;
            if (MemberDetail.Id > 0)
            {
                response = await sqliteService.UpdateItem(MemberDetail);
            }
            else
            {
                response = await sqliteService.AddItem(new Models.MemberModel
                {
                    Email = MemberDetail.Email,
                    FirstName = MemberDetail.FirstName,
                    LastName = MemberDetail.Address1,
                    Address1 = MemberDetail.Email,
                    Address2 = MemberDetail.Address2,
                    City = MemberDetail.City,
                    State = MemberDetail.State,
                    Zip = MemberDetail.Zip,
                    HairColor = MemberDetail.HairColor,
                    Height = MemberDetail.Height,
                    FavoriteColor = MemberDetail.FavoriteColor,
                    FavoriteHobby = MemberDetail.FavoriteHobby,
                    MothersName = MemberDetail.MothersName,
                    FathersName = MemberDetail.FathersName,
                });
            }



            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Member Info Saved", "Record Saved", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Heads Up!", "Something went wrong while adding record", "OK");
            }
        }

    }
}
