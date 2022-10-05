using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Taxes.Modules.Tax.Core;
using Taxes.Shared.Abstractions.Modules;

namespace Taxes.Modules.Tax.Api;

internal class TaxModule : IModule
{
    public string Name { get; } = "Tax";

    public IEnumerable<string> Policies { get; } = new[]
    {
        "noncash"
    };

    public void Register(IServiceCollection services)
    {
        services.AddCore();
    }

    public void Use(IApplicationBuilder app)
    {


    }
}