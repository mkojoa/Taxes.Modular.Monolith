using System.Collections.Generic;

namespace Taxes.Shared.Infrastructure.Modules;

internal class ModuleInfoProvider
{
    public List<ModuleInfo> Modules { get; } = new();
}