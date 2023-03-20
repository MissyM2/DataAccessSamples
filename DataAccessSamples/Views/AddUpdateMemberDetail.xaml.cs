namespace DataAccessSamples.Views;

public partial class AddUpdateMemberDetail : ContentPage
{ 
    public AddUpdateMemberDetail(AddUpdateMemberDetailVM vm)
    {
        InitializeComponent();
        this.BindingContext = vm;
    }
}
