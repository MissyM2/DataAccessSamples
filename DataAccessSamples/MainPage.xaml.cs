namespace DataAccessSamples;

public partial class MainPage : ContentPage
{

	public MainPage(MainPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    void ListView_ItemSelected(System.Object sender, Microsoft.Maui.Controls.SelectedItemChangedEventArgs e)
    {
		Shell.Current.DisplayAlert("ALert", e.SelectedItem.ToString(), "OK");
    }

}


