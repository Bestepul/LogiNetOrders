using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Hangfire;
using Microsoft.Extensions.Configuration;
using LogiNetOrders.Application.Repositories.Interfaces;
using LogiNetOrders.Application.Repositories;
using Hangfire.SqlServer;
using LogiNetOrders.Infrastructure.Services;


namespace LogiNetOrders.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddHangfire(config => config
        .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UseSqlServerStorage(configuration.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions
        {
            CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
            SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
            QueuePollInterval = TimeSpan.Zero,
            UseRecommendedIsolationLevel = true,
            DisableGlobalLocks = true
        }));
            services.AddHangfireServer();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));            
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddHttpClient<OrderService>();
            //services.AddSoapCore();
            //services.AddScoped<IOrderService, OrderService>();
            return services;
        }
    }
}
