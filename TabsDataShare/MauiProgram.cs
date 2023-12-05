using Microsoft.Extensions.Logging;
using TabsDataShare.Controls;
using TabsDataShare.Handlers;
using TabsDataShare.ViewModels;
using TabsDataShare.Views;

namespace TabsDataShare
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureMauiHandlers(handlers => {
                    handlers.AddHandler<TextSelectedEntry, TextSelectedEntryHandler>();
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<SharedViewModel>();
            builder.Services.AddTransient<Page1ViewModel>();

            builder.Services.AddTransient<EntryPage>();
            builder.Services.AddTransient<Page1>();
            builder.Services.AddTransient<Page2>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
