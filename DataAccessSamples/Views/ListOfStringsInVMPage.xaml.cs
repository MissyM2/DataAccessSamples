namespace DataAccessSamples.Views;

public partial class ListOfStringsInVMPage : ContentPage
{
	public ListOfStringsInVMPage(ListOfStringsInVMPageVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
