using System;
using System.Threading.Tasks;

namespace Taxes.Shared.Infrastructure.SqlServer;

public interface IUnitOfWork
{
    Task ExecuteAsync(Func<Task> action);
}