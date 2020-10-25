using System.Threading;
using System.Threading.Tasks;
using Otus.AG.Domain.Models;

namespace Otus.AG.Domain.Services
{
	public interface ICitiesService
	{
		Task<Page<City>> GetCitiesAsync(string template, int rowPerPage, int pageNumber,CancellationToken token);
	}
}