using System.Net.Http;
using Trailblazer.Services;
using Trailblazer.ViewModels;
using Trailblazer.Views;

namespace Trailblazer;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<IDataService, DataService>();
        builder.Services.AddSingleton<IJsonService, JsonService>();

        builder.Services.AddTransient<MainPageViewModel>();
        builder.Services.AddTransient<MainPage>();

		builder.Services.AddHttpClient<ServerAPIClient>(client => client.BaseAddress = new Uri("https://localhost:7031"));

        return builder.Build();
	}
}
