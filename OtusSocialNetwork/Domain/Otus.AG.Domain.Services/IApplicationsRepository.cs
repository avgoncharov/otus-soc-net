using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Otus.AG.Domain.Models;

namespace Otus.AG.Domain.Services
{
	public interface IApplicationsRepository
	{
		Task CreateAsync(Guid senderId, Guid receiverId,CancellationToken token);
		
		
		Task<IReadOnlyCollection<Application>> GetApplicationsAsync(
			Guid receiverId,
			int rowPerPage, 
			int pageNumber,
			CancellationToken token);
		
		
		Task UpdateApplicationAsync(
			Guid receiverId,
			Guid applicationId,
			bool accept,
			CancellationToken token);
	}
}