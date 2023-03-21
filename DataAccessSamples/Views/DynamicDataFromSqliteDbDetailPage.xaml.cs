namespace DataAccessSamples.Views;

public partial class DynamicDataFromSqliteDbDetailPage : ContentPage
{
	public DynamicDataFromSqliteDbDetailPage(DynamicDataFromSqliteDbDetailPageVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
