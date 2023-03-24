using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace DataAccessSamples.ViewModels
{
	public partial class SqliteMainPageVM : BaseVM
	{
        ISqliteService sqliteService;

        public ObservableCollection<MemberModel> SourceItems { get; set; } = new();
        public ObservableCollection<MemberModel> SearchResults { get; set; } = new();

        [ObservableProperty]
        string selectedListItem;


        public SqliteMainPageVM(ISqliteService sqliteService)
		{
			this.sqliteService = sqliteService;
			
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
    }
}

