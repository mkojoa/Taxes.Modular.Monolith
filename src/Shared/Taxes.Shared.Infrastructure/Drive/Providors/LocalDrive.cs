using Taxes.Shared.Infrastructure.Drive.Model;
using Taxes.Shared.Infrastructure.Drive.Services;

namespace Taxes.Shared.Infrastructure.Drive.Providors
{
    internal class LocalDrive : DriveService<LocalDriveModel>
    {
        protected override string ProcessDrive(LocalDriveModel model)
        {
            if (Helper.HasBase64File(model.FileInBase64))
            {
                if (Helper.IsValidBase64String(model.FileInBase64))
                {
                    var ext = Helper.GetFileExtensionFromBase64(model.FileInBase64);
                    var filePath = Helper.GetFilePath(model.Folder);
                    var fileWithoutBase = Helper.PrepareFile(model.FileInBase64);
                    if (fileWithoutBase != null)
                    {
                       return Helper.FileCommit(ext, fileWithoutBase, filePath, model.Id.ToLower());
                    }
                } 
            }

            return string.Empty;
        }

        protected override string ToBase64(LocalDriveModel model)
        {
            if (Helper.IsImageFile(model.Id))
            {
                var folderPath = Helper.GetFilePath(model.Folder);
                var fileWithFolderPath = folderPath + model.Id;

                if (Helper.FileExist(fileWithFolderPath))
                {
                    return Helper.ToBase64(fileWithFolderPath);
                }
            }
            return string.Empty;
        }
    }
}
