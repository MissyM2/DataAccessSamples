using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace DataAccessSamples.ViewModels
{
    public partial class SqliteMainPageVM : BaseVM
    {
        ISqliteService sqliteService;

        public ObservableCollection<MemberModel> SourceItems { get; set; } = new();
        public ObservableCollection<MemberModel> SearchResults { get; set; } = new();

        [ObservableProperty]
        int collectionViewHeight;

        [ObservableProperty]
        string selectedItem;

        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        bool isBusy;

        [ObservableProperty]
        bool isNotLoading;

        // properties for adding item
        [ObservableProperty]
        string firstName;
        [ObservableProperty]
        string lastName;
        [ObservableProperty]
        string email;
        [ObservableProperty]
        int memberId;

        [ObservableProperty]
        string addEditButtonText;




        public SqliteMainPageVM(ISqliteService sqliteService)
        {
            this.sqliteService = sqliteService;

        }

        public async Task InitializeAsync()
        {
            CollectionViewHeight = DeviceInfo.Current.Platform == DevicePlatform.iOS
                 ? Convert.ToInt32(DeviceDisplay.Current.MainDisplayInfo.Height / 2) - 150
                 : Convert.ToInt32(DeviceDisplay.Current.MainDisplayInfo.Height / 2) - 525;

            await GetAll();
        }

        [RelayCommand]
        async Task LoadMoreData()
        {
            await Shell.Current.DisplayAlert("OK", "Load more data code goes here", "OK");
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

        [RelayCommand]
        public async void AddUpdateMember()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateMemberDetailPage));
        }

        [RelayCommand]
        public async void EditMember(MemberModel memberModel)
        {
            var navParam = new Dictionary<string, object>();
            navParam.Add("MemberDetail", memberModel);
            await AppShell.Current.GoToAsync(nameof(AddUpdateMemberDetailPage), navParam);
        }

        [RelayCommand]
        public async void DeleteMember(MemberModel memberModel)
        {
            var delResponse = await sqliteService.DeleteItem(memberModel);
            if (delResponse > 0)
            {
                await GetAll();
            }
        }

        [RelayCommand]
        async Task Refresh()
        {
            //IsBusy = true;

            //await Task.Delay(2000);

            //Coffee.Clear();
            //LoadMore();

            //IsBusy = false;
        }

        [RelayCommand]
        void LoadMore()
        {
            //if (Coffee.Count >= 20)
            //    return;

            //var image = "coffeebag.png";
            //Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Sip of Sunshine", Image = image });
            //Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Potent Potable", Image = image });
            //Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Potent Potable", Image = image });
            //Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu Handege", Image = image });
            //Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Kenya Kiambu Handege", Image = image });

            //CoffeeGroups.Clear();

            //CoffeeGroups.Add(new Grouping<string, Coffee>("Blue Bottle", Coffee.Where(c => c.Roaster == "Blue Bottle")));
            //CoffeeGroups.Add(new Grouping<string, Coffee>("Yes Plz", Coffee.Where(c => c.Roaster == "Yes Plz")));
        }

        [RelayCommand]
        void DelayLoadMore()
        {
            //if (Coffee.Count <= 10)
            //    return;

            //LoadMore();
        }

        [RelayCommand]
        void Clear()
        {
            //Coffee.Clear();
            //CoffeeGroups.Clear(
        }
    }

}

