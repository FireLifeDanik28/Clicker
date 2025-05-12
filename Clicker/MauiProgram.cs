using Plugin.Maui.Audio;
using Microsoft.Extensions.Logging;

namespace Clicker
{
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
                    fonts.AddFont("digital-7.ttf", "Digital-7");
                    fonts.AddFont("digital-7 (italic).ttf", "Digital-7 Italic");
                    fonts.AddFont("digital-7 (mono).ttf", "Digital-7 Mono");
                    fonts.AddFont("digital-7 (mono italic).ttf", "Digital-7 Mono Italic");
                });
            builder.Services.AddSingleton(AudioManager.Current);
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
