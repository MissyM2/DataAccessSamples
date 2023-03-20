using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace DataAccessSamples.ViewModels
{
    [QueryProperty(nameof(MemberDetail), "MemberDetail")]
    public partial class AddUpdateMemberDetailVM : ObservableObject
    {
        [ObservableProperty]
        private MemberModel _memberDetail = new MemberModel();

        private readonly IMemberService _memberService;

        public AddUpdateMemberDetailVM(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [RelayCommand]
        public async void AddUpdateMember()
        {
            int response = -1;
            if (MemberDetail.Id > 0)
            {
                response = await _memberService.UpdateMember(MemberDetail);
            }
            else
            {
                response = await _memberService.AddMember(new Models.MemberModel
                {
                    Email = MemberDetail.Email,
                    FirstName = MemberDetail.FirstName,
                    LastName = MemberDetail.LastName,
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

