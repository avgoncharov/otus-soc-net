using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Otus.AG.Domain.Models;

namespace Otus.AG.Domain.Services
{
	public interface IUsersRepository
	{
		Task<Guid> CreateAsync(string login, string pswd, CancellationToken token);
		Task<User> GetByIdAsync(Guid id, CancellationToken token);
		Task<IReadOnlyCollection<User>> GetByFilterAsync(UsersFilter filter, CancellationToken token);
		Task<User> UpdateAsync(User user, CancellationToken token);
		Task<IReadOnlyCollection<User>> GetFriendsAsync(Guid userId, int rpp, int pn, CancellationToken token);
	}
}