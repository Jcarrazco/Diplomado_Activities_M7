using HolaMundo.ServicioConfiguracion.Services;
using Microsoft.Extensions.Logging;

namespace HolaMundo.ServicioConfiguracion
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
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<InicioSessionService>();
            builder.Services.AddSingleton<ConfiguracionService>();
            builder.Services.AddSingleton<UnidadTrabajoService>();
            builder.Services.AddSingleton<ProductoService>();

            return builder.Build();
        }
    }
}
