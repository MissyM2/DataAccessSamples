using DataAccessSamples.ViewModels;

namespace DataAccessSamples.Views;

public partial class DynamicDataDetailPage : ContentPage
{
	public DynamicDataDetailPage(DynamicDataDetailVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

   
}
