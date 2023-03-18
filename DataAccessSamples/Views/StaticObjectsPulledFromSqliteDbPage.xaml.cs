namespace DataAccessSamples.Views;

public partial class StaticObjectsPulledFromSqliteDbPage : ContentPage
{
	public StaticObjectsPulledFromSqliteDbPage(StaticObjectsPulledFromSqliteDbPageVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
