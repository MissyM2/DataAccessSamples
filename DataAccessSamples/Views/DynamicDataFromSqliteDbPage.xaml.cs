
namespace DataAccessSamples.Views;

public partial class DynamicDataFromSqliteDbPage : ContentPage
{
	public DynamicDataFromSqliteDbPage(DynamicDataFromSqliteDbPageVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is DynamicDataFromSqliteDbPageVM vm)
        {
            vm.GetMemberListCommand.Execute(null);
        }
    }
}
