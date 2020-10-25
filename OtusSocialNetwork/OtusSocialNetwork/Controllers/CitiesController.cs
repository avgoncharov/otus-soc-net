using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Otus.AG.Domain.Services;

namespace OtusSocialNetwork.Controllers
{
	[ApiController]
	[Route("api/v1/Cities")]
	public class CitiesController: ControllerBase
	{
		private readonly ICitiesService _citiesService;
		private readonly ILogger _logger;
		
		public CitiesController(ICitiesService citiesService, ILoggerFactory logger)
		{
			_citiesService = citiesService ?? throw new ArgumentNullException(nameof(citiesService));
			_logger = logger.CreateLogger("Default");
		}

		[HttpGet("{template}/{pn}")]
		public async Task<IActionResult> GetAsync(string template, int pn, CancellationToken token)
		{
			var result = await _citiesService.GetCitiesAsync(template, 100, pn, token)
				.ConfigureAwait(false);
			return Ok(result);
		}
	}
}