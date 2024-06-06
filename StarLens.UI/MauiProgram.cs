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
using StarLens.Persistance.Postgres.Data;
using System.Reflection;

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
                .AddSingleton<SearchPage>()
                .AddSingleton<AddPublicationPage>()
                .AddSingleton<ForumPage>()
                .AddSingleton<AddSessionPage>()
                .AddSingleton<UserViewPage>()
                .AddSingleton<TopicViewPage>()
                .AddSingleton<AddTopicPage>()
                .AddTransient<PublicationViewPage>();
            return services;
        }
        static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services
                .AddSingleton<LogInViewModel>()
                .AddSingleton<RegistrationViewModel>()
                .AddSingleton<UserViewModel>()
                .AddSingleton<FeedViewModel>()
                .AddSingleton<SearchViewModel>()
                .AddSingleton<ForumViewModel>()
                .AddSingleton<AddPublicationViewModel>()
                .AddSingleton<AddSessionViewModel>()
                .AddSingleton<UserViewViewModel>()
                .AddSingleton<TopicViewViewModel>()
                .AddSingleton<AddTopicViewModel>()
                .AddTransient<PublicationViewViewModel>();
            
            return services;
        }
        public static MauiApp CreateMauiApp()
        {
            string settingsStream = "StarLens.UI.appsettings.json";
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream(settingsStream);
            builder.Configuration.AddJsonStream(stream);
            var connStr = builder.Configuration.GetConnectionString("SqliteConnection");
            string dataDirectory = FileSystem.Current.AppDataDirectory + "/";
            connStr = String.Format(connStr, dataDirectory);
            var options = new DbContextOptionsBuilder<AppDbContext>()
             .UseSqlite(connStr)
             .Options;

            builder.Services
                .AddApplication()
                .AddPersistence()
                .RegisterPages()
                .RegisterViewModels();
            //DbInitializer.Initialize(builder.Services.BuildServiceProvider()).Wait();
#if DEBUG
            builder.Logging.AddDebug();
#endif



            return builder.Build();
        }
    }
}
