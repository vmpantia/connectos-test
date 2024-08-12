﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ACME.Core.Extensions
{
    public static class ServiceExtension
    {
        public static void AddCore(this IServiceCollection services) =>
            services.AddAutoMapper()
                    .AddMediatR();

        private static IServiceCollection AddAutoMapper(this IServiceCollection services) =>
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

        private static IServiceCollection AddMediatR(this IServiceCollection services) =>
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
    }
}
