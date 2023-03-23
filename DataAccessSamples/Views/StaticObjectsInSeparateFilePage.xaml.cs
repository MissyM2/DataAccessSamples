namespace DataAccessSamples.Views;

public partial class StaticObjectsInSeparateFilePage : ContentPage
{
	public StaticObjectsInSeparateFilePage(StaticObjectsInSeparateFilePageVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    void CollectionView_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        string memberName = (e.CurrentSelection.FirstOrDefault() as MemberModel).LastName;
        // The following route works because route names are unique in this application.
        //await Shell.Current.GoToAsync($"monkeydetails?name={memberName}");
        // The full route is shown below.
        // await Shell.Current.GoToAsync($"//animals/monkeys/monkeydetails?name={monkeyName}");
    }
}
