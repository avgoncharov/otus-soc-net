using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Otus.AG.Domain.Services;

namespace OtusSocialNetwork.Controllers
{
	[ApiController]
	[Route("api/v1/applications")]
	public class ApplicationsController : ControllerBase
	{
		private readonly IApplicationsService _applicationsService;
		private readonly ILogger _logger;
		
		public ApplicationsController(IApplicationsService applicationsService, ILoggerFactory logger)
		{
			_applicationsService = applicationsService ?? throw new ArgumentNullException(nameof(applicationsService));
			_logger = logger.CreateLogger("Default");
		}
	}
}