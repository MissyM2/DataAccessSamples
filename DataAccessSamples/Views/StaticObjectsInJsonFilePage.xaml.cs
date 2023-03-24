namespace DataAccessSamples.Views;

public partial class StaticObjectsInJsonFilePage : ContentPage
{
	public StaticObjectsInJsonFilePage(StaticObjectsInJsonFilePageVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();

		if (BindingContext is StaticObjectsInJsonFilePageVM vm)
		{
			await vm.InitializeAsync();
		}

			
	}

    void searchBar_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        if (e.NewTextValue == "")
        {
            if (BindingContext is StaticObjectsInJsonFilePageVM vm)
            {
                vm.PerformSearch("");
            }
        }
    }
}
