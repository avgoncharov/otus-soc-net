using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;
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

		public async Task<Guid> CreateAsync(string login, string pswd, CancellationToken token)
		{
			await using var cmd = _connection.CreateCommand();
			
			cmd.CommandText = "Insert into log_users (id, login, pswd) value (UUID_TO_BIN(@id), @login, @pswd)";
			cmd.CommandType = CommandType.Text;
			var newId = Guid.NewGuid();
			var idP = new MySqlParameter("@id", MySqlDbType.Guid) {Value = newId};
			cmd.Parameters.Add(idP);
			
			var loginP = new MySqlParameter("@login", MySqlDbType.VarChar) {Value = login};
			cmd.Parameters.Add(loginP);
			
			using var md5 = MD5.Create();
			var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(pswd));
			var pswdP = new MySqlParameter("@pswd", MySqlDbType.VarChar) {Value = Convert.ToBase64String(hash)};
			cmd.Parameters.Add(pswdP);
			
			var result = await cmd.ExecuteNonQueryAsync(token).ConfigureAwait(false);
			if (result == 1)
			{
				return newId;
			}

			return Guid.Empty;
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