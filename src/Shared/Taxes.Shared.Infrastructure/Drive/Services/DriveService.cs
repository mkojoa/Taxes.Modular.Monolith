using Taxes.Shared.Infrastructure.Drive.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxes.Shared.Infrastructure.Drive.Services;

internal abstract class DriveService<TModel> : IDriveService  
    where TModel : IDriveModel
{
    public virtual bool AppliesTo(Type provider)
    {
        return typeof(TModel).Equals(provider);
    }

    public string ProcessDrive<T>(T model) where T : IDriveModel
    {
        return ProcessDrive((TModel)(object)model);
    }

    public string ToBase64<T>(T model) where T : IDriveModel
    {
        return ToBase64((TModel)(object)model);
    }

    protected abstract string ProcessDrive(TModel model);

    protected abstract string ToBase64(TModel model);
}

