using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Taxes.Shared.Abstractions.Dispatchers;
using Taxes.Shared.Abstractions.Modules;
using Taxes.Shared.Abstractions.Storage;
using Taxes.Shared.Abstractions.Time;
using Taxes.Shared.Infrastructure.Api;
using Taxes.Shared.Infrastructure.Auth;
using Taxes.Shared.Infrastructure.Commands;
using Taxes.Shared.Infrastructure.Contexts;
using Taxes.Shared.Infrastructure.Contracts;
using Taxes.Shared.Infrastructure.Dispatchers;
using Taxes.Shared.Infrastructure.Drive;
using Taxes.Shared.Infrastructure.Events;
using Taxes.Shared.Infrastructure.Exceptions;
using Taxes.Shared.Infrastructure.Kernel;
using Taxes.Shared.Infrastructure.Logging;
using Taxes.Shared.Infrastructure.Messaging;
using Taxes.Shared.Infrastructure.Messaging.Outbox;
using Taxes.Shared.Infrastructure.Modules;
using Taxes.Shared.Infrastructure.Queries;
using Taxes.Shared.Infrastructure.Security;
using Taxes.Shared.Infrastructure.Serialization;
using Taxes.Shared.Infrastructure.Services;
using Taxes.Shared.Infrastructure.SqlServer;
using Taxes.Shared.Infrastructure.Storage;
using Taxes.Shared.Infrastructure.Swagger;
using Taxes.Shared.Infrastructure.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

 
namespace Taxes.Shared.Infrastructure;

public static class Extensions
{
    private const string CorrelationIdKey = "correlation-id";

    public static IServiceCollection AddInitializer<T>(this IServiceCollection services) where T : class, IInitializer
        => services.AddTransient<IInitializer, T>();

    public static IServiceCollection AddModularInfrastructure(this IServiceCollection services,
        IList<Assembly> assemblies, IList<IModule> modules)
    {
        var disabledModules = new List<string>();
        using (var serviceProvider = services.BuildServiceProvider())
        {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            foreach (var (key, value) in configuration.AsEnumerable())
            {
                if (!key.Contains(":module:enabled"))
                {
                    continue;
                }

                if (!bool.Parse(value))
                {
                    disabledModules.Add(key.Split(":")[0]);
                }
            }
        }

        services.AddCorsPolicy();
        var jwtOptions = services.GetOptions<JwtOptions>("jwt");
        var swaggerOptions = services.GetOptions<SwaggerOptions>("swagger");
        services.AddSwaggerDocs(swaggerOptions, jwtOptions);

        var appOptions = services.GetOptions<AppOptions>("app");
        services.AddSingleton(appOptions);

        services.UseDriveStore();
        services.AddMemoryCache();
        services.AddHttpClient();
        services.AddSingleton<IRequestStorage, RequestStorage>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddSingleton<IJsonSerializer, SystemTextJsonSerializer>();
        services.AddModuleInfo(modules);
        services.AddModuleRequests(assemblies);
        services.AddAuth(modules);
        services.AddErrorHandling();
        services.AddContext();
        services.AddCommands(assemblies);
        services.AddQueries(assemblies);
        services.AddEvents(assemblies);
        services.AddDomainEvents(assemblies);
        services.AddMessaging();
        services.AddSecurity();
        services.AddSingleton<IClock, UtcClock>();
        services.AddSingleton<IDispatcher, InMemoryDispatcher>();
        services.AddLoggingDecorators();
        services.AddSqlServer();
        services.AddOutbox();
        services.AddHostedService<DbContextAppInitializer>();
        services.AddContracts();
        services.AddControllers()
            .ConfigureApplicationPartManager(manager =>
            {
                var removedParts = new List<ApplicationPart>();
                foreach (var disabledModule in disabledModules)
                {
                    var parts = manager.ApplicationParts.Where(x => x.Name.Contains(disabledModule,
                        StringComparison.InvariantCultureIgnoreCase));
                    removedParts.AddRange(parts);
                }

                foreach (var part in removedParts)
                {
                    manager.ApplicationParts.Remove(part);
                }

                manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
            });

        return services;
    }

    public static IApplicationBuilder UseModularInfrastructure(this IApplicationBuilder app)
    {
        //app.UseForwardedHeaders(new ForwardedHeadersOptions
        //{
        //    ForwardedHeaders = ForwardedHeaders.All
        //});
        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
        });
        app.UseCors("cors");
        app.UseCorrelationId();
        app.UseErrorHandling();
        app.UseSwagger();
        app.UseSwaggerDocs();
        app.UseRouting();
        app.UseAuth();
        app.UseContext();
        app.UseLogging();

        return app;
    }

    public static T GetOptions<T>(this IServiceCollection services, string sectionName) where T : new()
    {
        using var serviceProvider = services.BuildServiceProvider();
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();
        return configuration.GetOptions<T>(sectionName);
    }

    public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : new()
    {
        var options = new T();
        configuration.GetSection(sectionName).Bind(options);
        return options;
    }

    public static string GetModuleName(this object value)
        => value?.GetType().GetModuleName() ?? string.Empty;

    public static string GetModuleName(this Type type, string namespacePart = "Modules", int splitIndex = 2)
    {
        if (type?.Namespace is null)
        {
            return string.Empty;
        }

        return type.Namespace.Contains(namespacePart)
            ? type.Namespace.Split(".")[splitIndex].ToLowerInvariant()
            : string.Empty;
    }

    public static IApplicationBuilder UseCorrelationId(this IApplicationBuilder app)
        => app.Use((ctx, next) =>
        {
            ctx.Items.Add(CorrelationIdKey, Guid.NewGuid());
            return next();
        });

    public static Guid? TryGetCorrelationId(this HttpContext context)
        => context.Items.TryGetValue(CorrelationIdKey, out var id) ? (Guid)id : null;
}