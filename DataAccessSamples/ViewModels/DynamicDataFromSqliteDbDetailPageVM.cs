using System;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Web;

namespace DataAccessSamples.ViewModels
{
    [QueryProperty(nameof(MemberModel), "MemberModel")]
    public partial class DynamicDataFromSqliteDbDetailPageVM : BaseViewModel
    {
        private readonly IMemberService _memberService;

        [ObservableProperty]
        MemberModel memberModel;

        public DynamicDataFromSqliteDbDetailPageVM(IMemberService memberService)
        {
            _memberService = memberService;
        }
    }

    //[RelayCommand]
    //public async void AddUpdateMember()
    //{
    //    int response = -1;
    //    if (MemberModel.Id > 0)
    //    {
    //        response = await _memberService.UpdateMember(MemberModel);
    //    }
    //    else
    //    {
    //        response = await _memberService.AddMember(new Models.MemberModel
    //        {
    //            Email = MemberModel.Email,
    //            FirstName = MemberModel.FirstName,
    //            LastName = MemberModel.LastName,
    //        });
    //    }



    //    if (response > 0)
    //    {
    //        await Shell.Current.DisplayAlert("Member Info Saved", "Record Saved", "OK");
    //    }
    //    else
    //    {
    //        await Shell.Current.DisplayAlert("Heads Up!", "Something went wrong while adding record", "OK");
    //    }
    //}
}