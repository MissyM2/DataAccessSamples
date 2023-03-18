namespace DataAccessSamples;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .RegisterAppServices()
            .RegisterViewsAndViewModels()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		return builder.Build();
	}

    public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<IDialogService, DialogService>();

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViewsAndViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        // PAGES AND VIEW MODELS
        mauiAppBuilder.Services.AddSingleton<MainPage>();
        mauiAppBuilder.Services.AddSingleton<MainPageViewModel>();

        mauiAppBuilder.Services.AddSingleton<ArrayOfStringsInXamlPage>();

        mauiAppBuilder.Services.AddSingleton<ArrayOfObjectsInXamlPage>();

        mauiAppBuilder.Services.AddSingleton<ListOfStringsInVMPage>();
        mauiAppBuilder.Services.AddSingleton<ListOfStringsInVMPageVM>();

        mauiAppBuilder.Services.AddSingleton<StaticObjectsInVMPage>();
        mauiAppBuilder.Services.AddSingleton<StaticObjectsInVMPageVM>();

        mauiAppBuilder.Services.AddSingleton<StaticObjectsInSeparateFilePage>();
        mauiAppBuilder.Services.AddSingleton<StaticObjectsInSeparateFilePageVM>();

        mauiAppBuilder.Services.AddSingleton<StaticObjectsInJsonFilePage>();
        mauiAppBuilder.Services.AddSingleton<StaticObjectsInJsonFilePageVM>();

        mauiAppBuilder.Services.AddSingleton<StaticObjectsPulledFromSqliteDbPage>();
        mauiAppBuilder.Services.AddSingleton<StaticObjectsPulledFromSqliteDbPageVM>();


        return mauiAppBuilder;
    }
}

