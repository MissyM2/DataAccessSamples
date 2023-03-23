using System;
using CommunityToolkit.Mvvm.Input;

namespace DataAccessSamples.ViewModels
{
	public partial class StaticObjectsInSeparateFilePageVM : BaseViewModel
	{
		public StaticObjectsInSeparateFilePageVM()
		{
		}

        //[RelayCommand]
        //public async Task PerformSearch(string searchTerm)
        //{

        //    if (string.IsNullOrWhiteSpace(searchTerm))
        //    {
        //        searchTerm = string.Empty;
        //    }

        //    searchTerm = searchTerm.ToLower();
        //    var filteredItems = SourceItems.Where(value => value.LastName.ToLower().Contains(searchTerm)).ToList();

        //    foreach (var value in SourceItems)
        //    {
        //        if (!filteredItems.Contains(value))
        //        {
        //            SearchResults.Remove(value);
        //        }
        //        else if (!SearchResults.Contains(value))
        //        {
        //            SearchResults.Add(value);
        //        }
        //    }


        //}
    }
}

