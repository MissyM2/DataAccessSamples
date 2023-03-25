namespace DataAccessSamples;

public partial class App : Application
{
	public static ISqliteService SqliteService { get; private set; }

	public App(ISqliteService sqliteService)
	{
		InitializeComponent();

		MainPage = new AppShell();

		SqliteService = sqliteService;
	}
    protected override Window CreateWindow(IActivationState activationState)
    {
        Window window = base.CreateWindow(activationState);

        window.Created += (s, e) =>
        {
            SqliteService.CheckDatabase();
        };

        return window;
    }
}

