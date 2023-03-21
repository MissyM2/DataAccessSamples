namespace DataAccessSamples.Views;

public partial class StaticObjectsInJsonFileDetailPage : ContentPage
{
	public StaticObjectsInJsonFileDetailPage(StaticObjectsInJsonFileDetailPageVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
