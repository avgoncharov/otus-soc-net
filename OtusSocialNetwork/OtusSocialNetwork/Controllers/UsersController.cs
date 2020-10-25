using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Otus.AG.Domain.Models;
using Otus.AG.Domain.Services;

namespace OtusSocialNetwork.Controllers
{
	[ApiController]
	[Route("api/v1/users")]
	public class UsersController : ControllerBase
	{
		private readonly IUsersServices _usersServices;
		private readonly ILogger _logger;

		public UsersController(IUsersServices usersServices, ILoggerFactory logger)
		{
			_usersServices = usersServices ?? throw new ArgumentNullException(nameof(usersServices));
			_logger = logger.CreateLogger("Default");
		}
		
		
		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken token)
		{
			_logger?.LogDebug($"GetByIdAsync ['{id.ToString()}']");
			var result = await _usersServices.GetUserByIdAsync(id, token).ConfigureAwait(false);
			if (result == null)
			{
				return NotFound();
			}

			return Ok(result);
		}
		
		
		[HttpGet("{id}/{rpp}/{pn}")]
		public async Task<IActionResult> GetFriendsForAsync(Guid id,int rpp, int pn, CancellationToken token)
		{
			if (rpp <= 0)
			{
				return BadRequest("Parameter 'row per page' must be greater than 0.");
			}
			
			if (pn <= 0)
			{
				return BadRequest("Parameter 'page number' must be greater than, or equals 0.");
			}

			var result = await _usersServices.GetFriendsForAsync(id, rpp, pn, token).ConfigureAwait(false);
			return Ok(result);
		}

		
		[HttpPost("by-filter")]
		public async Task<IActionResult> GetByFilterAsync([FromBody]UsersFilter filter, CancellationToken token)
		{
			_logger?.LogDebug("GetAsync");
			var result = await _usersServices.FindUsersAsync(filter, token).ConfigureAwait(false);
			return Ok(result);
		}
		
		
		[HttpGet]
		public async Task<IActionResult> GetAsync(CancellationToken token)
		{
			_logger?.LogDebug("GetAsync");
			var result = await _usersServices.FindUsersAsync(UsersFilter.Empty, token).ConfigureAwait(false);
			return Ok(result);
		}
	}
}