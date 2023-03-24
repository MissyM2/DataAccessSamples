using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace DataAccessSamples.ViewModels
{
    public partial class BaseVM : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        [ObservableProperty]
        string title;

        public bool IsNotBusy => !IsBusy;
    }
}

