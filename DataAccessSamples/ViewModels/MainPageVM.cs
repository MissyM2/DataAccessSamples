using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace DataAccessSamples.ViewModels
{
	public partial class MainPageVM : BaseVM
    {

        private IDialogService dialogService;
        

        readonly IList<ListItem> source;

        public ObservableCollection<ListItem> ListItems { get; private set; }

        [ObservableProperty]
        string selectedListItem;


        public MainPageVM(IDialogService dialogService)
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

            if (listItem.ItemPage == "MainPage")
            {
                await dialogService.ShowAlertAsync("MainPage", "No where to navigate to", "OK", null);
                return;
            }

            SelectedListItem = listItem.ItemPage;

            await Shell.Current.GoToAsync(SelectedListItem);
        }

        void CreateListItemCollection()
        {
            source.Add(new ListItem
            {
                ItemName = "CVSqliteMain",
                ItemPage = "CVSqlitePage",
                ItemDesc = "LV; SearchBar;Obs Coll; Main => Detail,body extracted to a control TapGesture;data from sqlite db; both LVDynamicDataPage and CVDynamicDataPage to to the same vm, detail page, pull same data",
            });

            source.Add(new ListItem
            {
                ItemName = "LVSqliteMain",
                ItemPage = "LVSqlitePage",
                ItemDesc = "LV; SearchBar;Obs Coll; Main => Detail,body extracted to a control TapGesture;data from sqlite db; both LVDynamicDataPage and CVDynamicDataPage to to the same vm, detail page, pull same data",
            });
           
            source.Add(new ListItem
            {
                ItemName = "CV/Static1",
                ItemPage = "StaticObjectsInSeparateFilePage",
                ItemDesc = "Collection of objects coming from a separate class; data coming from separate file",
            });

            source.Add(new ListItem
            {
                ItemName = "CV/Static2",
                ItemPage = "StaticObjectsInJsonFilePage",
                ItemDesc = "CV;Search, Obs Collection; Main -> Detail, TapGestureRecog,data from external json file",
            });

            source.Add(new ListItem
            {
                ItemName = "CV/Dynamic: Member",
                ItemPage = "DynamicDataFromSqliteDbPage",
                ItemDesc = "CV; Obs Coll; Main -> Detail, Tap;  dadta from Sqlite DB",
            });
            source.Add(new ListItem
            {
                ItemName = "LV/StaticA: This List",
                ItemPage = "MainPage",
                ItemDesc = "This page; LV; TapGesture; Obs Coll; iList ",
            });

            source.Add(new ListItem
            {
                ItemName = "LV/Static1: Fruit",
                ItemPage="ArrayOfStringsInXamlPage",
                ItemDesc = "List of strings within XAML; no separate class",
            });
            source.Add(new ListItem
            {
                ItemName = "LV/Static2: Person",
                ItemPage = "ArrayOfObjectsInXamlPage",
                ItemDesc = "Object Array within Xaml;with separate class",
            });

            source.Add(new ListItem
            {
                ItemName = "LV/Static3: Fruit ",
                ItemPage = "ListOfStringsInVMPage",
                ItemDesc = "Picker;List of strings coming from VM; no separate class",
            });

            source.Add(new ListItem
            {
                ItemName = "LV/Static4: Monkeys",
                ItemPage = "StaticObjectsInVMPage",
                ItemDesc = "ObservableCollection of objects coming from VM; with separate class",
            });

            

            ListItems = new ObservableCollection<ListItem>(source);
        }

    }
}

