using Microsoft.Extensions.Logging;
using MoipaUI.Servers;
using MoipaUI.ViewModels;
using MoipaUI.Views;

namespace MoipaUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("AlimamaShuHeiTi-Bold.ttf", "AlimamaShuHeiTiBold");
                //fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<LoginPageViewModel>();
        builder.Services.AddSingleton<DashboardPage>();
        builder.Services.AddSingleton<DashboardPageViewModel>();
        builder.Services.AddSingleton<UserPageViewModel>();
        builder.Services.AddSingleton<IMqttServer, MqttServer>();


        return builder.Build();
    }
}