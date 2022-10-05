using System.Threading.Tasks;

namespace Taxes.Shared.Infrastructure;

public interface IInitializer
{
    Task InitAsync();
}