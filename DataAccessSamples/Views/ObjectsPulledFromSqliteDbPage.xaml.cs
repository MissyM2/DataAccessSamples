namespace DataAccessSamples.Views;

public partial class StaticObjectsPulledFromSqliteDbPage : ContentPage
{
	public StaticObjectsPulledFromSqliteDbPage(StaticObjectsPulledFromSqliteDbPageVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        collectionView.ItemsSource = await App.Database.GetMembersAsync();
    }

    async void OnButtonClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(nameEntry.Text))
        {
            await App.Database.SaveMemberAsync(new Member
            {
                Name = nameEntry.Text,
                Subscribed = subscribed.IsChecked
            });

            nameEntry.Text = string.Empty;
            subscribed.IsChecked = false;

            collectionView.ItemsSource = await App.Database.GetMembersAsync();
        }
    }

    Member lastSelection;
    void collectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
    {
        lastSelection = e.CurrentSelection[0] as Member;

        nameEntry.Text = lastSelection.Name;
        subscribed.IsChecked = lastSelection.Subscribed;
    }

    // Update
    async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        if (lastSelection != null)
        {
            lastSelection.Name = nameEntry.Text;
            lastSelection.Subscribed = subscribed.IsChecked;

            await App.Database.UpdateMemberAsync(lastSelection);

            collectionView.ItemsSource = await App.Database.GetMembersAsync();
        }
    }

    // Delete
    async void Button_Clicked_1(System.Object sender, System.EventArgs e)
    {
        if (lastSelection != null)
        {
            await App.Database.DeleteMemberAsync(lastSelection);

            collectionView.ItemsSource = await App.Database.GetMembersAsync();

            nameEntry.Text = "";
            subscribed.IsChecked = false;
        }
    }

    // Get subscribed
    async void Button_Clicked_2(System.Object sender, System.EventArgs e)
    {
        collectionView.ItemsSource = await App.Database.QuerySubscribedAsync();
    }

    // Get Not Subscribed
    async void Button_Clicked_3(System.Object sender, System.EventArgs e)
    {
        collectionView.ItemsSource = await App.Database.LinqNotSubscribedAsync();
    }
}
}
}
