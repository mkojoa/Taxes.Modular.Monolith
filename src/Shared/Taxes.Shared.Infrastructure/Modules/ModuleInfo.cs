using System.Collections.Generic;

namespace Taxes.Shared.Infrastructure.Modules;

internal record ModuleInfo(string Name, IEnumerable<string> Policies);