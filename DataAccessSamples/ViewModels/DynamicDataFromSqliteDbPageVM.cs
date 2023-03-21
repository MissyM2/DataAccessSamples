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
        public ObservableCollection<MemberModel> SourceItems { get; set; } = new();
        public ObservableCollection<MemberModel> SearchResults { get; set; } = new();

        IMemberService memberService;

        public DynamicDataFromSqliteDbPageVM(IMemberService memberService)
        {
            this.memberService = memberService;
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
                var memberList = await memberService.GetMemberList();

                if (SourceItems.Count != 0)
                    SourceItems.Clear();

                if (SearchResults.Count != 0)
                    SearchResults.Clear();

                foreach (var member in memberList)
                {
                    SourceItems.Add(member);
                    SearchResults.Add(member);
                }
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

        [RelayCommand]
        public async Task PerformSearch(string searchTerm)
        {

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = string.Empty;
            }

            searchTerm = searchTerm.ToLower();
            var filteredItems = SourceItems.Where(value => value.LastName.ToLower().Contains(searchTerm)).ToList();

            foreach (var value in SourceItems)
            {
                if (!filteredItems.Contains(value))
                {
                    SearchResults.Remove(value);
                }
                else if (!SearchResults.Contains(value))
                {
                    SearchResults.Add(value);
                }
            }


        }

        [RelayCommand]
        async Task GoToDetails(MemberModel memberModel)
        {
            if (memberModel == null) return;

            await Shell.Current.GoToAsync(nameof(AddUpdateMemberDetail), true, new Dictionary<string, object>
                {
                    {"MemberModel", memberModel}
                });
        }



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