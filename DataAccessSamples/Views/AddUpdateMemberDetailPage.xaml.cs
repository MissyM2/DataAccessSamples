namespace DataAccessSamples.Views;

public partial class AddUpdateMemberDetailPage : ContentPage
{
	public AddUpdateMemberDetailPage(AddUpdateMemberDetailVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    void scrollView_Scrolled(System.Object sender, Microsoft.Maui.Controls.ScrolledEventArgs e)
    {
        Console.WriteLine($"ScrollX: {e.ScrollX}, ScrollY: {e.ScrollY}");
    }

    async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        await scrollView.ScrollToAsync(finalLabel, ScrollToPosition.End, true);
    }
}
