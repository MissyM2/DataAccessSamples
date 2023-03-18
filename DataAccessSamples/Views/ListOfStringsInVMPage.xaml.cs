namespace DataAccessSamples.Views;

public partial class ListOfStringsInVMPage : ContentPage
{
	public ListOfStringsInVMPage(ListOfStringsInVMPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
