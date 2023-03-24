using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;


namespace DataAccessSamples.ViewModels
{
	public partial class DynamicDataVM : BaseVM
	{
        ISqliteService sqliteService;
        private IDialogService dialogService;

        public ObservableCollection<MemberModel> SourceItems { get; set; } = new();
        public ObservableCollection<MemberModel> SearchResults { get; set; } = new();

        [ObservableProperty]
        string selectedListItem;

        public DynamicDataVM(SqliteService sqliteService, IDialogService dialogService)
        {
            this.sqliteService = sqliteService;
            this.dialogService = dialogService;
        }

        public async Task InitializeAsync()
        {
            await GetAll();
        }

        [RelayCommand]
        async Task GetAll()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var itemList = await sqliteService.GetListAsync();

                if (SourceItems.Count != 0)
                    SourceItems.Clear();

                if (SearchResults.Count != 0)
                    SearchResults.Clear();

                foreach (var item in itemList)
                {
                    SourceItems.Add(item);
                    SearchResults.Add(item);
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
        async Task GoToDetails(MemberModel memberModel)
        {
            if (memberModel == null)
                return;

            await Shell.Current.GoToAsync(nameof(DynamicDataDetailPage), true, new Dictionary<string, object>
            {
                {"MemberModel", memberModel }
            });
        }

        [RelayCommand]
        public void PerformSearch(string searchTerm)
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
        //        App.SqliteService.UpdateMember(member);
        //        await Shell.Current.DisplayAlert("Info", App.SqliteService.StatusMessage, "Ok");
        //    }
        //    else
        //    {
        //        App.SqliteService.AddMember(member);
        //        await Shell.Current.DisplayAlert("Info", App.SqliteService.StatusMessage, "Ok");
        //    }

        //  await GetMemberList();
        // await ClearForm();
        //}

        //[RelayCommand]
        //public async void DeleteMember(MemberModel memberModel)
        //{

        //    var result = App.SqliteService.DeleteMember(memberModel);

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
        //    var member = App.SqliteService.GetMember(id);
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