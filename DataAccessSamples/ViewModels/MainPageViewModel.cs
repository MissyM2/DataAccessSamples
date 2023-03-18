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
                ItemName = "ArrayStringsXaml",
                ItemPage="ArrayOfStringsInXamlPage",
                ItemDesc = "List of strings within XAML; no class",
            });
            source.Add(new ListItem
            {
                ItemName = "ArrayObjectsXaml",
                ItemPage = "ArrayOfObjectsInXamlPage",
                ItemDesc = "List of objects with XAML; with class",
            });

            source.Add(new ListItem
            {
                ItemName = "ListStringsVM",
                ItemPage = "ListOfStringsInVMPage",
                ItemDesc = "List of objects with XAML; with class",
            });

            source.Add(new ListItem
            {
                ItemName = "CollectionObjects",
                ItemPage = "StaticObjectsInVMPage",
                ItemDesc = "Collection of objects coming from VM; with class",
            });

            source.Add(new ListItem
            {
                ItemName = "Objects from separate file",
                ItemPage = "StaticObjectsInSeparateFilePage",
                ItemDesc = "Collection of objects coming from a separate class",
            });

            source.Add(new ListItem
            {
                ItemName = "Json",
                ItemPage = "StaticObjectsInJsonFilePage",
                ItemDesc = "Collection of objects coming from json file",
            });

            source.Add(new ListItem
            {
                ItemName = "SQL Lite db",
                ItemPage = "StaticObjectsPulledFromSqliteDbPage",
                ItemDesc = "sqlite db",
            });

            ListItems = new ObservableCollection<ListItem>(source);
        }

    }
}

