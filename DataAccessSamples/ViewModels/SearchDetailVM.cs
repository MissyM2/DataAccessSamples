using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace DataAccessSamples.ViewModels
{
    [QueryProperty(nameof(StudentCase), "StudentCase")]
    public partial class SearchDetailVM : BaseViewModel
    {
        [ObservableProperty]
        StudentCase studentCase;

        public SearchDetailVM()
        {

        }

    }
}

