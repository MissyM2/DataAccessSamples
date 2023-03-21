using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace DataAccessSamples.ViewModels
{
    [QueryProperty(nameof(StudentCase), "StudentCase")]
    public partial class StaticObjectsInJsonFileDetailPageVM : BaseViewModel
	{
        [ObservableProperty]
        StudentCase studentCase;

        public StaticObjectsInJsonFileDetailPageVM()
		{
		}
	}

}

