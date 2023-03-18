using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace DataAccessSamples.ViewModels
{
	public class MainPageViewModel : BaseViewModel
    {
        readonly IList<ListItem> source;
        ListItem selectedListItem;

        public ObservableCollection<ListItem> ListItems { get; private set; }

        public ListItem SelectedListItem
        {
            get
            {
                return selectedListItem;
            }
            set
            {
                if (selectedListItem != value)
                {
                    selectedListItem = value;
                }
            }
        }


        public MainPageViewModel()
        {
            source = new List<ListItem>();
            CreateListItemCollection();

            SelectedListItem = ListItems.Skip(3).FirstOrDefault();
            OnPropertyChanged("SelectedListItem");

        }

        void CreateListItemCollection()
        {
            
            source.Add(new ListItem
            {
                ItemName = "List of Strings",
                ItemDesc = "List of strings coming from VM; no class",
            });

            source.Add(new ListItem
            {
                ItemName = "Collection of Objects",
                ItemDesc = "Collection of objects coming from VM; with class",
            });

            source.Add(new ListItem
            {
                ItemName = "Objects from separate file",
                ItemDesc = "Collection of objects coming from a separate class",
            });

            source.Add(new ListItem
            {
                ItemName = "Json",
                ItemDesc = "Collection of objects coming from json file",
            });

            source.Add(new ListItem
            {
                ItemName = "SQL Lite db",
                ItemDesc = "sqlite db",
            });

            ListItems = new ObservableCollection<ListItem>(source);
        }

    }
}

