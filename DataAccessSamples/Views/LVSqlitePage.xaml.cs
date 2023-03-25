namespace DataAccessSamples.Views;

public partial class LVSqlitePage : ContentPage
{
	public LVSqlitePage(SqliteMainPageVM vm)
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

    void OnMore_Clicked(System.Object sender, System.EventArgs e)
    {
        var mi = ((MenuItem)sender);
        DisplayAlert("More Context Action", mi.CommandParameter + " more context action", "OK");
    }

    void OnDelete_Clicked_1(System.Object sender, System.EventArgs e)
    {
        var mi = ((MenuItem)sender);
        DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");

        //Debug.WriteLine("delete " + mi.CommandParameter.ToString());
        //items.Remove(mi.CommandParameter.ToString());
    }
}
