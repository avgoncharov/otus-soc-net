using System.Threading;
using System.Threading.Tasks;

namespace Otus.AG.Domain.Services
{
	public interface IUnitOfWorkFactory
	{
		Task<IUnitOfWork> CreateAsync(CancellationToken token);
	}
}