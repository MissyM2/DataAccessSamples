using System;
using DataAccessSamples.Models;

namespace DataAccessSamples.ViewModels
{
    [QueryProperty(nameof(MemberModel), "MemberModel")]
    public partial class DynamicDataDetailVM : BaseVM
    {
        [ObservableProperty]
        MemberModel memberModel;

        public DynamicDataDetailVM()
        {

        }

    }
}

