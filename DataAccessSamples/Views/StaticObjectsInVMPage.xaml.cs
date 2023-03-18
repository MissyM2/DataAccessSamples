namespace DataAccessSamples.Views;

public partial class StaticObjectsInVMPage : ContentPage
{
	public StaticObjectsInVMPage(StaticObjectsInVMPageVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
