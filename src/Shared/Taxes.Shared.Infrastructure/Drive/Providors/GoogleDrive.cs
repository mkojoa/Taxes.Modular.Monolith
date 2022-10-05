using Taxes.Shared.Infrastructure.Drive.Model;
using Taxes.Shared.Infrastructure.Drive.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxes.Shared.Infrastructure.Drive.Providors
{
    internal class GoogleDrive : DriveService<GoogleDriveModel>
    {
        protected override string ProcessDrive(GoogleDriveModel model)
        {
            //Implementation GoogleDrive File Save
            return "";
        }

        protected override string ToBase64(GoogleDriveModel model)
        {
            throw new NotImplementedException();
        }
    }
}
