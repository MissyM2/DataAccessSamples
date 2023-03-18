namespace DataAccessSamples.Views;

public partial class StaticObjectsInJsonFilePage : ContentPage
{
	public StaticObjectsInJsonFilePage(StaticObjectsInJsonFilePageVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
