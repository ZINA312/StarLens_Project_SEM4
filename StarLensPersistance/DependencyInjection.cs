using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StarLens.Persistance.Postgres.Data;
using StarLens.Persistance.Postgres.Repository;

namespace StarLens.Persistance.Postgres
{

    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
       services)
        {
            services.AddSingleton<IUnitOfWork, FakeUnitOfWork>();
            return services;
        }
        public static IServiceCollection AddPersistence(
       this IServiceCollection services,
        DbContextOptions options)
        {
            services.AddPersistence()
            .AddSingleton<AppDbContext>(
           new AppDbContext((DbContextOptions<AppDbContext>)options));
            return services;
        }
    }

}
