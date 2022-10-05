using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Taxes.Shared.Abstractions.Contexts;

namespace Taxes.Shared.Infrastructure.Contexts;

public static class Extensions
{
    public static IServiceCollection AddContext(this IServiceCollection services)
    {
        services.AddSingleton<ContextAccessor>();
        services.AddTransient(sp => sp.GetRequiredService<ContextAccessor>().Context);
        services.AddSingleton<IUserContext, UserContext>();


        return services;
    }

    public static IApplicationBuilder UseContext(this IApplicationBuilder app)
    {
        app.Use((ctx, next) =>
        {
            ctx.RequestServices.GetRequiredService<ContextAccessor>().Context = new Context(ctx);

            return next();
        });

        return app;
    }
}