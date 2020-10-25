using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Otus.AG.Domain.Models;
using Otus.AG.Domain.Services;

namespace Otus.AG.Infra.DAL.MySql
{
	internal sealed class ApplicationsRepository: IApplicationsRepository
	{
		internal ApplicationsRepository(MySqlConnection connection)
		{
			_connection = connection;
		}

		public async Task CreateAsync(Guid senderId, Guid receiverId, CancellationToken token)
		{
			throw new NotImplementedException();
		}

		public async Task<IReadOnlyCollection<Application>> GetApplicationsAsync(Guid receiverId, int rowPerPage, int pageNumber, CancellationToken token)
		{
			throw new NotImplementedException();
		}

		public async Task UpdateApplicationAsync(Guid receiverId, Guid applicationId, bool accept, CancellationToken token)
		{
			throw new NotImplementedException();
		}
		
		
		private readonly MySqlConnection _connection;
	}
}