using System;
using System.Threading;
using System.Threading.Tasks;
using Otus.AG.Domain.Models;

namespace Otus.AG.Domain.Services
{
	public interface IApplicationsService
	{
		public Task RegisterApplicationAsync(Guid senderId, Guid receiverId,CancellationToken token);
		
		
		public Task<Page<Application>> GetApplicationsAsync(
			Guid receiverId,
			int rowPerPage, 
			int pageNumber,
			CancellationToken token);
		
		
		public Task AcceptApplicationAsync(
			Guid receiverId,
			Guid applicationId,
			CancellationToken token);
		
		
		public Task DeclineApplicationAsync(
			Guid receiverId,
			Guid applicationId,
			CancellationToken token);
	}
}