using Microsoft.Extensions.DependencyInjection;
using Taxes.Shared.Infrastructure.Drive.Model;
using Taxes.Shared.Infrastructure.Drive.Providors;
using Taxes.Shared.Infrastructure.Drive.Services;
using Taxes.Shared.Infrastructure.Drive.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxes.Shared.Infrastructure.Drive
{
    internal static class Extensions 
    {
        public static IServiceCollection UseDriveStore(this IServiceCollection services) 
        {
            services.AddSingleton<IDriveModel, GoogleDriveModel>();
            services.AddSingleton<IDriveModel, LocalDriveModel>();

            IDriveStrategy driveStrategy = new DriveStrategy(
                new IDriveService[]
                { 
                    new GoogleDrive(),
                    new LocalDrive()
                }
            );

            services.AddSingleton(driveStrategy);

            return services;
        }
    }
}
