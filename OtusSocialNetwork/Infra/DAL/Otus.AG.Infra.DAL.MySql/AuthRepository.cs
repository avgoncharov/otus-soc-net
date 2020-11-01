using System;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Otus.AG.Domain.Models;
using Otus.AG.Domain.Services;

namespace Otus.AG.Infra.DAL.MySql
{
	internal sealed class AuthRepository:IAuthRepository
	{
		public AuthRepository(MySqlConnection connection)
		{
			_connection = connection;
		}
		
		public async Task<Guid> LoginAsync(string login, string pswd, CancellationToken token)
		{
			await using var cmd = _connection.CreateCommand();
			
			cmd.CommandText = "select BIN_TO_UUID(id) id from log_users where login=@login and pswd=@pswd";
			cmd.CommandType = CommandType.Text;
			
			var p = new MySqlParameter("@login", MySqlDbType.VarChar) {Value = login};
			cmd.Parameters.Add(p);
			
			using var md5 = MD5.Create();
			var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(pswd));
			var pswdP = new MySqlParameter("@pswd", MySqlDbType.VarChar) {Value = Convert.ToBase64String(hash)};
			cmd.Parameters.Add(pswdP);
			
			await using var reader = await cmd.ExecuteReaderAsync(token).ConfigureAwait(false);
			if (reader.HasRows)
			{
				await reader.ReadAsync(token).ConfigureAwait(false);
				return Guid.Parse(reader["id"].ToString());
			}

			return Guid.Empty;
		}
		
		
		private readonly MySqlConnection _connection;
	}
}