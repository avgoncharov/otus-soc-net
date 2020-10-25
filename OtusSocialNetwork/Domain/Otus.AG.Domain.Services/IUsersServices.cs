using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Otus.AG.Domain.Models;

namespace Otus.AG.Domain.Services
{
	public interface IUsersServices
	{
		Task<User> CreateUserAsync(User user, CancellationToken token);
		
		
		Task<User> GetUserByIdAsync(Guid userId, CancellationToken token);
		
		
		Task<User> UpdateUserAsync(
			string name,
			string lastname,
			DateTime? dateOfBirth, 
			IReadOnlyCollection<string> interests,
			City city,
			CancellationToken token);
		
		
		Task DeactivateUserAsync(Guid userGuid, CancellationToken token);

		
		Task<Page<User>> FindUsersAsync(UsersFilter filter, CancellationToken token);
		
		
		Task<Page<User>> GetFriendsForAsync(
			Guid userId,
			int rowPerPage,
			int pageNumber,
			CancellationToken token);
	}
}