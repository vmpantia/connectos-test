using ACME.Domain.Contracts;
using ACME.Infrastructure.Database.Contexts;
using ACME.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ACME.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDatabases(configuration)
                    .AddRepositories();

        private static IServiceCollection AddDatabases(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<ACMEDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("MigrationDb")));

        private static IServiceCollection AddRepositories(this IServiceCollection services) =>
            services.AddScoped<ICustomerRepository, CustomerRepository>()
                    .AddScoped<ISubscriptionRepository, SubscriptionRepository>()
                    .AddScoped<IPublicationRepository, PublicationRepository>()
                    .AddScoped<IPrintDistributorRepository, PrintDistributorRepository>();
    }
}
