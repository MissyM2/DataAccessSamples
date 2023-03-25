using CommunityToolkit.Maui;
using DataAccessSamples.Data;

namespace DataAccessSamples;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
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
        mauiAppBuilder.Services.AddSingleton<StudentCaseService>();
        mauiAppBuilder.Services.AddSingleton<ISqliteService, SqliteService>();

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViewsAndViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        // PAGES AND VIEW MODELS
        mauiAppBuilder.Services.AddSingleton<MainPage>();
        mauiAppBuilder.Services.AddSingleton<MainPageVM>();

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

        mauiAppBuilder.Services.AddSingleton<StaticObjectsInJsonFileDetailPage>();
        mauiAppBuilder.Services.AddSingleton<StaticObjectsInJsonFileDetailPageVM>();

        mauiAppBuilder.Services.AddSingleton<CVSqlitePage>();
        mauiAppBuilder.Services.AddSingleton<LVSqlitePage>();
        mauiAppBuilder.Services.AddSingleton<SqliteMainPageVM>();

        mauiAppBuilder.Services.AddSingleton<AddUpdateMemberDetailPage>();
        mauiAppBuilder.Services.AddSingleton<AddUpdateMemberDetailVM>();



        mauiAppBuilder.Services.AddSingleton<DynamicDataDetailPage>();
        mauiAppBuilder.Services.AddSingleton<DynamicDataDetailVM>();


        return mauiAppBuilder;
    }
}

