using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Taxes.Shared.Infrastructure;
using Taxes.Shared.Infrastructure.Contracts;
using Taxes.Shared.Infrastructure.Messaging.Outbox;
using Taxes.Shared.Infrastructure.SqlServer;
using Taxes.Modules.Tax.Core.DAL;
using Taxes.Modules.Tax.Core.DAL.Repositories;
using Taxes.Modules.Tax.Core.Domain.Repositories;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Taxes.Modules.Tax.Api")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace Taxes.Modules.Tax.Core;

internal static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        return
            services
                .AddScoped<ICountryRepository, CountryRepository>()
                .AddInitializer<TaxesInitializer>()
                .AddSqlServer<TaxesDbContext>()
                .AddOutbox<TaxesDbContext>()
                .AddUnitOfWork<TaxesUnitOfWork>();
    }

    public static void UseCore(this IApplicationBuilder app)
    {
        //app.UseContracts();
        //.Register<EmployeeCreatedContract>();
    }
}