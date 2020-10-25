using System;
using System.Threading;
using System.Threading.Tasks;
using Otus.AG.Domain.Models;

namespace Otus.AG.Domain.Services
{
	public interface ICitiesRepository
	{
		Task<Page<City>> GetCitiesAsync(string template, int rowPerPage, int pageNumber,CancellationToken token);
		Task<City> GetCityByIdAsync(Guid id,CancellationToken token);
		Task<City> GetCityByNameIdAsync(string name,CancellationToken token);
	}
}