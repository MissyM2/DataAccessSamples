namespace DataAccessSamples.Views;

public partial class CVSqlitePage : ContentPage
{
	public CVSqlitePage(SqliteMainPageVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is SqliteMainPageVM vm)
        {
            await vm.InitializeAsync();
        }
    }

    void searchBar_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        if (e.NewTextValue == "")
        {
            if (BindingContext is SqliteMainPageVM vm)
            {
                vm.PerformSearch("");
            }

        }
    }
}
