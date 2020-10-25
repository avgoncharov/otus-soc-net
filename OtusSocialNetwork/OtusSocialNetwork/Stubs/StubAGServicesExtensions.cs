using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Otus.AG.Domain.Services;

namespace OtusSocialNetwork.Stubs
{
	public static class StubAGServicesExtensions
	{
		public static IServiceCollection AddStubAgServices(this IServiceCollection services)
		{
			services.TryAddSingleton<IUsersServices, UsersServicesStub>();
			return services;
		}
	}
}