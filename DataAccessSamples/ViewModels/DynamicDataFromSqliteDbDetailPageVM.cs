using System;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Web;

namespace DataAccessSamples.ViewModels
{
    [QueryProperty(nameof(MemberModel), "MemberModel")]
    public partial class DynamicDataFromSqliteDbDetailPageVM : BaseViewModel
    {
        private readonly IMemberService _memberService;

        [ObservableProperty]
        MemberModel memberModel;

        public DynamicDataFromSqliteDbDetailPageVM(IMemberService memberService)
        {
            _memberService = memberService;
        }
    }
}

