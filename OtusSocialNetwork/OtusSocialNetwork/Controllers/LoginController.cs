using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Otus.AG.Domain.Services;
using OtusSocialNetwork.Models;

namespace OtusSocialNetwork.Controllers
{
	[ApiController]
	[Route("api/v1/login")]
	public class LoginController : ControllerBase
	{
		public LoginController(IConfiguration config, IUnitOfWorkFactory unitOfWorkFactory)
		{
			_unitOfWorkFactory = unitOfWorkFactory;
			_config = config;
		}
		

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> LoginAsync([FromBody] LoginUser login, CancellationToken token)
		{
			var response = Unauthorized();
			var user = await AuthenticateUserAsync(login, token);
			if (user == null)
			{
				return response;
			}
			
			var tokenString = GenerateJwtToken(user);
			return Ok(new {token = tokenString, userDetails = user.Login,});
		}
		
		
		[HttpPost("create")]
		[AllowAnonymous]
		public async Task<IActionResult> CreateUserAsync([FromBody] LoginUser login, CancellationToken token)
		{
			await using var uof = await _unitOfWorkFactory.CreateAsync(token).ConfigureAwait(false);
			var id = await uof.UsersRepository.CreateAsync(login.Login, login.Password, token).ConfigureAwait(false);
			if (id == Guid.Empty)
			{
				return BadRequest();
			}

			return Ok(id);
		}

		
		private async Task<LoginUser> AuthenticateUserAsync(LoginUser loginUser, CancellationToken token)
		{
			await using var uof = await _unitOfWorkFactory.CreateAsync(token).ConfigureAwait(false);
			var id = await uof.AuthRepository.LoginAsync(loginUser.Login, loginUser.Password, token).ConfigureAwait(false);

			if (id == Guid.Empty)
			{
				return null;
			}

			loginUser.Role = "user";
			return loginUser;
		}

		private string GenerateJwtToken(LoginUser userInfo)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, userInfo.Login),
				new Claim("role",userInfo.Role),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
			};
			var token = new JwtSecurityToken(issuer:
				_config["Jwt:Issuer"],
				audience: _config["Jwt:Audience"],
				claims: claims,
				expires: DateTime.Now.AddMinutes(30),
				signingCredentials: credentials);
			
			return new JwtSecurityTokenHandler().WriteToken(token);
		}
		
		
		private readonly IConfiguration _config;
		private readonly IUnitOfWorkFactory _unitOfWorkFactory;
	}
}