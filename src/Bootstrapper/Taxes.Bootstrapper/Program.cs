using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Taxes.Shared.Infrastructure.Logging;
using Taxes.Shared.Infrastructure.Modules;
using System.Threading.Tasks;

namespace Taxes.Bootstrapper;

public class Program
{
    public static Task Main(string[] args)
        => CreateHostBuilder(args).Build().RunAsync();

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
            .ConfigureModules()
            .UseLogging();
}