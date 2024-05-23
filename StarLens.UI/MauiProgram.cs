using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using StarLens.UI.Pages;
using StarLens.UI.ViewModels;
using StarLens.Applicationn;
using StarLens.Domain;
using StarLens.Persistance.Postgres;
using Microsoft.Maui.Controls;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace StarLens.UI
{
    public static class MauiProgram
    {
        static IServiceCollection RegisterPages(this IServiceCollection services)
        {
            services
                .AddSingleton<LogInPage>()
                .AddSingleton<RegistrationPage>()
                .AddSingleton<UserPage>()
                .AddSingleton<FeedPage>()
                .AddSingleton<SearchPage>();
            return services;
        }
        static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services
                .AddSingleton<LogInViewModel>()
                .AddSingleton<RegistrationViewModel>()
                .AddSingleton<UserViewModel>()
                .AddSingleton<FeedViewModel>()
                .AddSingleton<SearchViewModel>();
            
            return services;
        }
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services
                .AddApplication()
                .AddPersistence()
                .RegisterPages()
                .RegisterViewModels();



            return builder.Build();
        }
    }
}
