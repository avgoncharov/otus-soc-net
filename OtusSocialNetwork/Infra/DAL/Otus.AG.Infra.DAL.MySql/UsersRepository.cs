using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Otus.AG.Domain.Models;
using Otus.AG.Domain.Services;

namespace Otus.AG.Infra.DAL.MySql
{
	internal sealed class UsersRepository: IUsersRepository
	{
		internal UsersRepository(MySqlConnection connection)
		{
			_connection = connection;
		}

		public async Task<User> CreateAsync(User user, CancellationToken token)
		{
			throw new NotImplementedException();
		}

		public async Task<User> GetByIdAsync(Guid id, CancellationToken token)
		{
			throw new NotImplementedException();
		}

		public async Task<IReadOnlyCollection<User>> GetByFilterAsync(UsersFilter filter, CancellationToken token)
		{
			throw new NotImplementedException();
		}

		public async Task<User> UpdateAsync(User user, CancellationToken token)
		{
			throw new NotImplementedException();
		}

		public async Task<IReadOnlyCollection<User>> GetFriendsAsync(Guid userId, int rpp, int pn, CancellationToken token)
		{
			throw new NotImplementedException();
		}
		
		
		private readonly MySqlConnection _connection;
	}
}