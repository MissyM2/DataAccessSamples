using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace DataAccessSamples.ViewModels
{
	public partial class MainPageViewModel : BaseViewModel
    {

        private IDialogService dialogService;
        

        readonly IList<ListItem> source;

        public ObservableCollection<ListItem> ListItems { get; private set; }

        [ObservableProperty]
        string selectedListItem;


        public MainPageViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            source = new List<ListItem>();
            CreateListItemCollection();


        }

        [RelayCommand]
        async Task ItemTapped(ListItem listItem)
        {
            if (listItem == null)
            {
                return;
            }

            SelectedListItem = listItem.ItemPage;

            //await dialogService.ShowAlertAsync("OK", "ItemTapped " + SelectedListItem, "OK", null);

            await Shell.Current.GoToAsync(SelectedListItem);
        }

        void CreateListItemCollection()
        {
            
            source.Add(new ListItem
            {
                ItemName = "LV/Static: String Array within Xaml",
                ItemPage="ArrayOfStringsInXamlPage",
                ItemDesc = "List of strings within XAML; no class",
            });
            source.Add(new ListItem
            {
                ItemName = "LV/Static: Object Array within Xaml",
                ItemPage = "ArrayOfObjectsInXamlPage",
                ItemDesc = "List of objects with XAML; with class",
            });

            source.Add(new ListItem
            {
                ItemName = "LV/Static: String Array within VM",
                ItemPage = "ListOfStringsInVMPage",
                ItemDesc = "List of objects with XAML; with class",
            });

            source.Add(new ListItem
            {
                ItemName = "LV/Static: Collection of Objects within VM",
                ItemPage = "StaticObjectsInVMPage",
                ItemDesc = "Collection of objects coming from VM; with class",
            });

            source.Add(new ListItem
            {
                ItemName = "CV/Static: Collection of Objects pulled from separate file",
                ItemPage = "StaticObjectsInSeparateFilePage",
                ItemDesc = "Collection of objects coming from a separate class",
            });

            source.Add(new ListItem
            {
                ItemName = "CV/Static:  Collection of Objects pulled from separate JSON file",
                ItemPage = "StaticObjectsInJsonFilePage",
                ItemDesc = "Collection of objects coming from json file",
            });

            source.Add(new ListItem
            {
                ItemName = "CV/Dynamic: Collection of from Sqlite DB",
                ItemPage = "DynamicDataFromSqliteDbPage",
                ItemDesc = "DynamicDataFromSqliteDbPage",
            });

            ListItems = new ObservableCollection<ListItem>(source);
        }

    }
}

