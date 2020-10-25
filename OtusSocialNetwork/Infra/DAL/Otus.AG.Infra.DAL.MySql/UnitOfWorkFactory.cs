using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Otus.AG.Domain.Services;

namespace Otus.AG.Infra.DAL.MySql
{
	internal sealed class UnitOfWorkFactory: IUnitOfWorkFactory
	{
		private readonly string _connectionString;
		public UnitOfWorkFactory(IConfiguration config)
		{
			_connectionString = config.GetValue<string>("MySqlConnectionString");
		}

		public async Task<IUnitOfWork> CreateAsync(CancellationToken token)
		{
			var connection= new MySqlConnection(_connectionString);
			await connection.OpenAsync(token).ConfigureAwait(false);
			 
			return new UnitOfWork(connection);
		}
		
		
	}
}