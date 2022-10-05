using Taxes.Shared.Infrastructure.Drive.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxes.Shared.Infrastructure.Drive.Services
{
    internal interface IDriveService
    {
        string ProcessDrive<T>(T model) where T : IDriveModel;
        string ToBase64<T>(T model) where T : IDriveModel;
        bool AppliesTo(Type provider); 
    }
}
