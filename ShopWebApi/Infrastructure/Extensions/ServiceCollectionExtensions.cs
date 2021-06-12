using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using ShopWebApi.Data.EntityFramework;
using ShopWebApi.Data.Implementation;
using ShopWebApi.Data.Interfaces;
using ShopWebApi.Domain.Implementation;
using ShopWebApi.Domain.Interfaces;
using ShopWebApi.Jobs;
using ShopWebApi.Model;

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
            services.AddScoped<IProductInWarehouseRepository, ProductInWarehouseRepository>();
            services.AddScoped<IProductReservationRepository, ProductReservationRepository>();
        }
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductReservationManager, ProductReservationManager>();
        }
        public static void ConfigureJobs(this IServiceCollection services)
        {
            services.AddSingleton<IJobFactory, JobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            services.AddSingleton(new JobSchedule(
                                  jobType: typeof(ReservProductJob),
                                  cronExpression: "0/5 * * * * ?"));
            services.AddHostedService<QuartzHostedService>();
        }
    }
}
