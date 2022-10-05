using Taxes.Shared.Infrastructure.Drive.Model;
using Taxes.Shared.Infrastructure.Drive.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Taxes.Shared.Infrastructure.Drive.Strategy
{
    internal class DriveStrategy : IDriveStrategy
    {
        private readonly IEnumerable<IDriveService>  driveServices;

        public DriveStrategy(IEnumerable<IDriveService> driveServices)
        {
            this.driveServices = driveServices 
                ?? throw new ArgumentNullException(nameof(driveServices));
        }

        public string ProcessDrive<T>(T model) where T : IDriveModel
        {
            return GetDriveService(model).ProcessDrive(model);
        }

        public string ToBase64<T>(T model) where T : IDriveModel
        {
            return GetDriveService(model).ToBase64(model);
        }

        private IDriveService GetDriveService<T>(T model) where T : IDriveModel
        {
            var result = driveServices.FirstOrDefault(p => p.AppliesTo(model.GetType()));
            if (result == null)
            {
                throw new InvalidOperationException(
                    $"Drive service for {model.GetType()} not registered.");
            }
            return result;
        }
    }
}
