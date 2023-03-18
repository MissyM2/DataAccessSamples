namespace DataAccessSamples.Views;

public partial class StaticObjectsInVMPage : ContentPage
{
	public StaticObjectsInVMPage(StaticObjectsInVMPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
