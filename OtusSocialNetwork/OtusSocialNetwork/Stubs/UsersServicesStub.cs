using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Otus.AG.Domain.Models;
using Otus.AG.Domain.Services;

namespace OtusSocialNetwork.Stubs
{
	internal sealed class UsersServicesStub:IUsersServices
	{
		public async Task<User> CreateUserAsync(User user, CancellationToken token)
		{
			throw new NotImplementedException();
		}

		public  Task<User> GetUserByIdAsync(Guid userId, CancellationToken token)
		{
			return Task.FromResult(User);
		}

		public async Task<User> UpdateUserAsync(string name, string lastname, DateTime? dateOfBirth, IReadOnlyCollection<string> interests, City city,
			CancellationToken token)
		{
			throw new NotImplementedException();
		}

		public async Task DeactivateUserAsync(Guid userGuid, CancellationToken token)
		{
			throw new NotImplementedException();
		}

		public async Task<Page<User>> FindUsersAsync(UsersFilter filter, CancellationToken token)
		{
			if (filter.IsEmpty)
			{
				return new Page<User>
				{
					PageNumber = filter.PageNumber,
					RowPerPage = filter.RowPerPage,
					Items = new []{User}
				};
			}
			
			return new Page<User>{PageNumber = filter.RowPerPage, RowPerPage = filter.PageNumber, Items = Array.Empty<User>()};
		}

		public async Task<Page<User>> GetFriendsForAsync(Guid userId, int rowPerPage, int pageNumber, CancellationToken token)
		{
			throw new NotImplementedException();
		}

		private static User User =
			new User(
				Guid.Empty,
				Guid.Empty,
				"John",
				"Snow",
				new DateTime(1983,6,8), 
				Gender.Male,
				new[] {"music"},
				new City(Guid.Empty, "Spb"),
				Array.Empty<User>());
	}
}