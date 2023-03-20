using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace DataAccessSamples.ViewModels
{
	public partial class DynamicDataFromSqliteDbPageVM : BaseViewModel
    {
        public static List<MemberModel> MembersListForSearch { get; private set; } = new List<MemberModel>();
        public ObservableCollection<MemberModel> Members { get; set; } = new ObservableCollection<MemberModel>();

        private readonly IMemberService _memberService;

        public DynamicDataFromSqliteDbPageVM(IMemberService memberService)
        {
            _memberService = memberService;
        }



        [RelayCommand]
        public async void GetMemberList()
        {
            Members.Clear();
            var memberList = await _memberService.GetMemberList();
            if (memberList?.Count > 0)
            {
                memberList = memberList.OrderBy(f => f.LastName).ToList();
                foreach (var member in memberList)
                {
                    Members.Add(member);
                }
                MembersListForSearch.Clear();
                MembersListForSearch.AddRange(memberList);
            }
        }


        [RelayCommand]
        public async void AddUpdateMember()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateMemberDetail));
        }

        [RelayCommand]
        public async void EditMember(MemberModel memberModel)
        {
            var navParam = new Dictionary<string, object>();
            navParam.Add("MemberDetail", memberModel);
            await AppShell.Current.GoToAsync(nameof(AddUpdateMemberDetail), navParam);
        }

        [RelayCommand]
        public async void DeleteMember(MemberModel memberModel)
        {
            var delResponse = await _memberService.DeleteMember(memberModel);
            if (delResponse > 0)
            {
                GetMemberList();
            }
        }


        [RelayCommand]
        public async void DisplayAction(MemberModel memberModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");
            if (response == "Edit")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("MemberDetail", memberModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdateMemberDetail), navParam);
            }
            else if (response == "Delete")
            {
                var delResponse = await _memberService.DeleteMember(memberModel);
                if (delResponse > 0)
                {
                    GetMemberList();
                }
            }
        }
    }
}


