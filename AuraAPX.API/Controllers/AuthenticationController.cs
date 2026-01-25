using AuraAPX.API.Authentication.Dtos.ParameterDtos;
using AuraAPX.API.Authentication.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuraAPX.API.Controllers
{
	[Route("auth")]
	public class AuthenticationController : Controller
	{
		private readonly IJwtAuthenticationService _jwtAuthenticationService;
		public AuthenticationController(IJwtAuthenticationService jwtAuthenticationService)
		{
			_jwtAuthenticationService = jwtAuthenticationService;
		}


		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody]GetUserByCredentialsDto dto)
		{
			return Ok(await _jwtAuthenticationService.GetJwtAccessToken(dto.Login, dto.Password));
		}
	}
}
