namespace DataAccessSamples.Views;

public partial class SearchDetailPage : ContentPage
{
	public SearchDetailPage(SearchDetailVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
