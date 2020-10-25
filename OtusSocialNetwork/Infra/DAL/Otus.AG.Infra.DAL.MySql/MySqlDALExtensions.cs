using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Otus.AG.Domain.Services;

namespace Otus.AG.Infra.DAL.MySql
{
	public static class MySqlDALExtensions
	{
		public static IServiceCollection AddMySqlDAL(this IServiceCollection services)
		{
			services.TryAddSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>();
			return services;
		}
	}
}