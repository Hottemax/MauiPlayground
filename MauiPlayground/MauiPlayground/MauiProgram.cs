using CommunityToolkit.Maui;
using UraniumUI;

namespace MauiPlayground;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseUraniumUI()
            .UseUraniumUIMaterial()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                fonts.AddMaterialIconFonts();
            });

        builder.Services
            .AddCommunityToolkitDialogs()
            .AddLocalization();
        Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.Debug().CreateLogger();
        builder.Logging.AddSerilog();
        return builder.Build();
    }
}
