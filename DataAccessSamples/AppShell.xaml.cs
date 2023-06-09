﻿namespace DataAccessSamples;

public partial class AppShell : Shell
{
    public Dictionary<string, Type> Routes { get; private set; } = new Dictionary<string, Type>();

    public AppShell()
	{
		InitializeComponent();
		RegisterRoutes();
		BindingContext = this;
	}

    void RegisterRoutes()
    {
        Routes.Add(nameof(ArrayOfStringsInXamlPage), typeof(ArrayOfStringsInXamlPage));

        Routes.Add(nameof(ArrayOfObjectsInXamlPage), typeof(ArrayOfObjectsInXamlPage));

        Routes.Add(nameof(ListOfStringsInVMPage), typeof(ListOfStringsInVMPage));

        Routes.Add(nameof(StaticObjectsInVMPage), typeof(StaticObjectsInVMPage));

        Routes.Add(nameof(StaticObjectsInSeparateFilePage), typeof(StaticObjectsInSeparateFilePage));

        Routes.Add(nameof(StaticObjectsInJsonFilePage), typeof(StaticObjectsInJsonFilePage));
        Routes.Add(nameof(StaticObjectsInJsonFileDetailPage), typeof(StaticObjectsInJsonFileDetailPage));

        Routes.Add(nameof(CVSqlitePage), typeof(CVSqlitePage));
        Routes.Add(nameof(LVSqlitePage), typeof(LVSqlitePage));
        Routes.Add(nameof(DynamicDataDetailPage), typeof(DynamicDataDetailPage));

        Routes.Add(nameof(AddUpdateMemberDetailPage), typeof(AddUpdateMemberDetailPage));

        foreach (var item in Routes)
        {
            Routing.RegisterRoute(item.Key, item.Value);
        }
    }
}

