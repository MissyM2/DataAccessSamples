
namespace DataAccessSamples.Views;

public partial class DynamicDataFromSqliteDbPage : ContentPage
{
	public DynamicDataFromSqliteDbPage(DynamicDataFromSqliteDbPageVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is DynamicDataFromSqliteDbPageVM vm)
        {
            await vm.InitializeAsync();
        }
    }
}
