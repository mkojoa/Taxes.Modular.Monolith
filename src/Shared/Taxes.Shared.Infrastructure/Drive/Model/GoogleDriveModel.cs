using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxes.Shared.Infrastructure.Drive.Model
{
    public class GoogleDriveModel : IDriveModel
    {
        public string Id { get; set; }
        public string File { get; set; }
        public string[] Scopes { get; set; }
        public string Credential { get; set; }
        public string Application { get; set; }
    }
}
