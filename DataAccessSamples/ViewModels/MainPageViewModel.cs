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
                ItemName = "Howler Monkey",
                ItemDesc = "South America",
            });

            source.Add(new ListItem
            {
                ItemName = "Japanese Macaque",
                ItemDesc = "Japan",
            });

            source.Add(new ListItem
            {
                ItemName = "Mandrill",
                ItemDesc = "Southern Cameroon, Gabon, Equatorial Guinea, and Congo",
            });

            source.Add(new ListItem
            {
                ItemName = "Proboscis Monkey",
                ItemDesc = "Borneo",
            });

            source.Add(new ListItem
            {
                ItemName = "Red-shanked Douc",
                ItemDesc = "Vietnam, Laos",
            });

            source.Add(new ListItem
            {
                ItemName = "Gray-shanked Douc",
                ItemDesc = "Vietnam",
            });

            source.Add(new ListItem
            {
                ItemName = "Golden Snub-nosed Monkey",
                ItemDesc = "China",
          });


            ListItems = new ObservableCollection<ListItem>(source);
        }

        

        

    }
}

