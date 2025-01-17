using FinTracker.Services;
using FinTracker.Services.Interface;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using FinTracker.Models; // Ensure this line is included

namespace FinTracker
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
                });

            builder.Services.AddMauiBlazorWebView();

            // Register services
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ITransactionService, TransactionService>();
            builder.Services.AddScoped<IDebtService, DebtService>();
            builder.Services.AddScoped<ITagService, TagService>();

            // Register GlobalState as singleton
            builder.Services.AddSingleton<GlobalState>(); // Ensure this line is added

            // Add MudBlazor services
            builder.Services.AddMudServices();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
