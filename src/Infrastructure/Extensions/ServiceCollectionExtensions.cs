using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using AccountingApp.Application.Interfaces.Repositories;
using AccountingApp.Application.Interfaces.Services.Storage;
using AccountingApp.Application.Interfaces.Services.Storage.Provider;
using AccountingApp.Application.Interfaces.Serialization.Serializers;
using AccountingApp.Application.Serialization.JsonConverters;
using AccountingApp.Application.Serialization.Options;
using AccountingApp.Application.Serialization.Serializers;
using AccountingApp.Infrastructure.Services.Storage.Provider;
using AccountingApp.Infrastructure.Services.Storage;
using AccountingApp.Infrastructure.Repositories;

namespace AccountingApp.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddTransient(typeof(IRepositoryAsync<,>), typeof(RepositoryAsync<,>))
                //.AddTransient<IDocumentTypeRepository, DocumentTypeRepository>()
                .AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        }

        public static IServiceCollection AddServerStorage(this IServiceCollection services)
            => services.AddServerStorage(null);

        public static IServiceCollection AddServerStorage(this IServiceCollection services, Action<SystemTextJsonOptions> configure)
        {
            return services
                .AddScoped<IJsonSerializer, SystemTextJsonSerializer>()
                .AddScoped<IStorageProvider, ServerStorageProvider>()
                .AddScoped<IServerStorageService, ServerStorageService>()
                .AddScoped<ISyncServerStorageService, ServerStorageService>()
                .Configure<SystemTextJsonOptions>(configureOptions =>
                {
                    configure?.Invoke(configureOptions);
                    if (!configureOptions.JsonSerializerOptions.Converters.Any(c => c.GetType() == typeof(TimespanJsonConverter)))
                        configureOptions.JsonSerializerOptions.Converters.Add(new TimespanJsonConverter());
                });
        }
    }
}