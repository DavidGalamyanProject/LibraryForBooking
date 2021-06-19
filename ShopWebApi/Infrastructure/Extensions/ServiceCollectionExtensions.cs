using FluentScheduler;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using ShopWebApi.Data.EntityFramework;
using ShopWebApi.Data.Implementation;
using ShopWebApi.Data.Interfaces;
using ShopWebApi.Domain.Implementation;
using ShopWebApi.Domain.Interfaces;
using ShopWebApi.Domain.Job;
using System;

namespace ShopWebApi.Infrastructure.Extensions
{
    internal static class ServiceCollectionExtensions
    { 
        public static void ConfigureDbContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ShopDbContext>(options =>
            {
                options.UseNpgsql(
                    configuration.GetConnectionString("Postgres"),
                    b => b.MigrationsAssembly("ShopWebApi"));
            });
        }
        public static void ConfigureBackendSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LibraryForBookingGoods", Version = "v1" });
            });
        }
        public static void ConfigureDomainManagers(this IServiceCollection services)
        {
            services.AddScoped<IReservationManager, ReservationManager>();
            services.AddScoped<IWarehouseManager, WarehouseManager>();
            services.AddScoped<IProductManager, ProductManager>();
        }
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IWarehouseRepository, WarehouseRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }
        public static void ConfigureJobs(this IServiceCollection services)
        {
            JobManager.Initialize();
            JobManager.AddJob<JobReserv>(s => s.ToRunNow().AndEvery(3).Seconds());
        }
    }
}
