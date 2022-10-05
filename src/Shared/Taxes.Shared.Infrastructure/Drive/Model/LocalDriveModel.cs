using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxes.Shared.Infrastructure.Drive.Model
{
    public class LocalDriveModel : IDriveModel
    {
        public string Id { get; set; }
        public string FileInBase64 { get; set; }
        public string[] Folder { get; set; }
    }
}
