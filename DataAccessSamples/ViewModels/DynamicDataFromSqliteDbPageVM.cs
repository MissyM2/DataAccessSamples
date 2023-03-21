using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace DataAccessSamples.ViewModels
{
	public partial class DynamicDataFromSqliteDbPageVM : BaseViewModel
    {
        public static List<MemberModel> MembersListForSearch { get; private set; } = new List<MemberModel>();
        public ObservableCollection<MemberModel> SourceItems { get; }
        public ObservableCollection<MemberModel> SearchResults { get; set; } = new();

        IMemberService _memberService;

        [ObservableProperty]
        string firstName;

        public DynamicDataFromSqliteDbPageVM(IMemberService memberService)
        {
            _memberService = memberService;
            SourceItems = new ObservableCollection<MemberModel>();
        }

        public async Task InitializeAsync()
        {
            await GetAllMembersList();
        }



        [RelayCommand]
        async Task GetAllMembersList()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var memberList = await _memberService.GetMemberList();

                if (SourceItems.Count != 0)
                    SourceItems.Clear();

                if (SearchResults.Count != 0)
                    SearchResults.Clear();

                foreach (var member in memberList)
                {
                    SourceItems.Add(member);
                    SearchResults.Add(member);
                }

                MembersListForSearch.Clear();
                MembersListForSearch.AddRange(memberList);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get cases: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }

        }

    //[RelayCommand]
    //    async Task GetMemberDetails(int id)
    //    {
    //        if (id == 0) return;

    //        await Shell.Current.GoToAsync($"{nameof(DynamicDataFromSqliteDbDetailPage)}?Id={id}", true);
    //    }

        //[RelayCommand]
        //async Task SaveMember()
        //{
        //    if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(Email))
        //    {
        //        await Shell.Current.DisplayAlert("Invalid Data", "Please insert valid data", "Ok");
        //        return;
        //    }

        //    var member = new MemberModel
        //    {
        //        FirstName = FirstName,
        //        LastName = LastName,
        //        Email = Email
        //    };

        //    if (Id != 0)
        //    {
        //        member.Id = Id;
        //        App.MemberService.UpdateMember(member);
        //        await Shell.Current.DisplayAlert("Info", App.MemberService.StatusMessage, "Ok");
        //    }
        //    else
        //    {
        //        App.MemberService.AddMember(member);
        //        await Shell.Current.DisplayAlert("Info", App.MemberService.StatusMessage, "Ok");
        //    }

          //  await GetMemberList();
           // await ClearForm();
        //}

        //[RelayCommand]
        //public async void DeleteMember(MemberModel memberModel)
        //{

        //    var result = App.MemberService.DeleteMember(memberModel);

        //    if (result > 0)
        //    { 
        //        await GetMemberList();
        //    }
        //}

        //[RelayCommand]
        //async Task UpdateMember(int id)
        //{
        //    AddEditButtonText = editButtonText;
        //    return;
        //}

        //[RelayCommand]
        //async Task SetEditMode(int id)
        //{
        //    AddEditButtonText = editButtonText;
        //    Id = id;
        //    var member = App.MemberService.GetMember(id);
        //    FirstName = member.FirstName;
        //    LastName = member.LastName;
        //    Email = member.Email;
        //}

        //[RelayCommand]
        //async Task ClearForm()
        //{
        //    AddEditButtonText = createButtonText;
        //    MemberId = 0;
        //    FirstName = string.Empty;
        //    LastName = string.Empty;
        //    Email = string.Empty;
        //}
    }
}