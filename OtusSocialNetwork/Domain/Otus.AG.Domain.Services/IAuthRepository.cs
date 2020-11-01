using System;
using System.Threading;
using System.Threading.Tasks;

namespace Otus.AG.Domain.Services
{
	public interface IAuthRepository
	{
		Task<Guid> LoginAsync(string login, string pswd, CancellationToken token);
	}
}