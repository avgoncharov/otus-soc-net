using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Otus.AG.Domain.Services;
using OtusSocialNetwork.JwtPolicies;

namespace OtusSocialNetwork.Controllers
{
	[ApiController]
	[Route("api/v1/cities")]
	public class CitiesController: ControllerBase
	{
		public CitiesController(IUnitOfWorkFactory unitOfWorkFactory, ILoggerFactory logger)
		{
			_unitOfWorkFactory = unitOfWorkFactory ?? throw new ArgumentNullException(nameof(unitOfWorkFactory));
			_logger = logger.CreateLogger("Default");
		}
		
		[Authorize(Policy = Policies.User)]
		[HttpGet("by-template/{template}/{pn}")]
		public async Task<IActionResult> GetAsync(string template, int pn, CancellationToken token)
		{
			await using var uow = await _unitOfWorkFactory.CreateAsync(token).ConfigureAwait(false);
			
			var result = await uow.CitiesRepository.GetCitiesAsync(template, 100, pn, token)
				.ConfigureAwait(false);
			
			return Ok(result);
		}
		
		
		[HttpGet("{id}")]
		public async Task<IActionResult> GetAsync(Guid id, CancellationToken token)
		{
			await using var uow = await _unitOfWorkFactory.CreateAsync(token).ConfigureAwait(false);
			
			var result = await uow.CitiesRepository.GetCityByIdAsync(id, token)
				.ConfigureAwait(false);

			return result != null ? Ok(result): NotFound() as IActionResult;
		}
		
		
		[Authorize(Roles = "admin")]
		[HttpGet("by-name/{name}")]
		public async Task<IActionResult> GetAsync(string name, CancellationToken token)
		{
			await using var uow = await _unitOfWorkFactory.CreateAsync(token).ConfigureAwait(false);
			
			var result = await uow.CitiesRepository.GetCityByNameIdAsync(name, token)
				.ConfigureAwait(false);

			return result != null ? Ok(result): NotFound() as IActionResult;
		}
		
		
		private readonly IUnitOfWorkFactory _unitOfWorkFactory;
		private readonly ILogger _logger;

	}
}