namespace DataAccessSamples.Views;

public partial class StaticObjectsInSeparateFilePage : ContentPage
{
	public StaticObjectsInSeparateFilePage(StaticObjectsInSeparateFilePageVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
