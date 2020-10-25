using System;
using System.Threading;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Otus.AG.Domain.Services;

namespace Otus.AG.Infra.DAL.MySql
{
	internal sealed class UnitOfWork: IUnitOfWork
	{
		internal UnitOfWork(MySqlConnection connection)
		{
			_connection = connection;
			CitiesRepository =  new CitiesRepository(_connection);
			UsersRepository =  new UsersRepository(_connection);
			ApplicationsRepository = new ApplicationsRepository(_connection);
		}
		
		public ICitiesRepository CitiesRepository { get; }
		public IUsersRepository UsersRepository { get; }
		public IApplicationsRepository ApplicationsRepository { get; }

		
		public ValueTask DisposeAsync()
		{
			return new ValueTask(_connection.CloseAsync(CancellationToken.None));
		}
		
		
		private readonly MySqlConnection _connection;
	}
}