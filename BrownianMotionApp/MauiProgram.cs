using BrownianMotionApp.Services;
using BrownianMotionApp.Services.Interfaces;
using BrownianMotionApp.ViewModels;
using BrownianMotionApp.Views;
using InputKit.Handlers;
using Microsoft.Extensions.Logging;
using UraniumUI;
using UraniumUI.Dialogs;

namespace BrownianMotionApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureMauiHandlers(handlers =>
                {
                    handlers.AddInputKitHandlers();
                })
                .UseUraniumUI()
                .UseUraniumUIMaterial()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddMaterialSymbolsFonts();
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<IBrownianMotionService, BrownianMotionService>();

            builder.Services.AddTransient<BrownianMotionChartPage>();
            builder.Services.AddTransient<BrownianMotionChartViewModel>();

            return builder.Build();
        }
    }
}
