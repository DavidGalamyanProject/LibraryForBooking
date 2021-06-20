using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Quartz;
using ShopWebApi.Data.EntityFramework;
using ShopWebApi.Data.Implementation;
using ShopWebApi.Data.Interfaces;
using ShopWebApi.Domain.Implementation;
using ShopWebApi.Domain.Interfaces;
using ShopWebApi.Domain.Job;
using ShopWebApi.Infrastructure.Validation;
using ShopWebApi.Model.Dto;
using System;
using System.IO;
using System.Reflection;

namespace ShopWebApi.Infrastructure.Extensions
{
    internal static class ServiceCollectionExtensions
    { 
        public static void ConfigureDbContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            // Ссылка на базу в файле appsettings.json. Если вы хотите пользоваться этой платформой, 
            // необходимо вставить ссылку на сервер баз данных postgresql
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
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
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
            services.AddQuartz(q =>
            {
               
                q.UseMicrosoftDependencyInjectionScopedJobFactory();

                var reservJobKey = new JobKey("ReserveJob");

                q.AddJob<ReserveJob>(opts => opts.WithIdentity(reservJobKey));

                // Периодическая обработка очереди заказов
                q.AddTrigger(opts => opts
                    .ForJob(reservJobKey) 
                    .WithIdentity("ReserveJob-trigger") 
                    .StartAt(DateBuilder.EvenSecondDate(DateTimeOffset.UtcNow.AddSeconds(2)))
                    .WithSimpleSchedule(a => a.WithIntervalInSeconds(1).RepeatForever()));

            });

            services.AddQuartzHostedService(
                q => q.WaitForJobsToComplete = true);
        }
        public static void ConfigureValidation(this IServiceCollection services)
        {
            services.AddTransient<IValidator<ReservRequest>, ReservRequestValidator>();
        }
    }
}
