using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OtusSocialNetwork.Controllers
{
	[ApiController]
	[Route("api/v1/users")]
	public class Users : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAsync(CancellationToken token)
		{
			return Ok("Hello");
		}
	}
}