using System;

namespace Otus.AG.Domain.Services
{
	public interface IUnitOfWork: IAsyncDisposable
	{
		ICitiesRepository CitiesRepository { get; }
		IUsersRepository UsersRepository { get; }
		IApplicationsRepository ApplicationsRepository { get; }
		IAuthRepository AuthRepository { get; }
	}
}