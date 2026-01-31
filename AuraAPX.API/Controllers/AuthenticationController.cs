using AuraAPX.API.Authentication.Dtos.ParameterDtos;
using AuraAPX.API.Authentication.Dtos.ReturnedDtos;
using AuraAPX.API.Authentication.Services.Interfaces;
using AuraAPX.Application.Dtos.ParameterDtos;
using AuraAPX.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuraAPX.API.Controllers
{
	[Route("auth")]
	public class AuthenticationController : Controller
	{
		private readonly IJwtAuthenticationService _jwtAuthenticationService;
		private readonly IRefreshTokenService _refreshTokenService;
		private readonly IUserService _userService;
		public AuthenticationController(IJwtAuthenticationService jwtAuthenticationService, IUserService userService, IRefreshTokenService refreshTokenService)
		{
			_jwtAuthenticationService = jwtAuthenticationService;
			_userService = userService;
			_refreshTokenService = refreshTokenService;
		}


		//Получение access-токена по логину и паролю.
		[AllowAnonymous]
		[HttpPost("login")]
		public async Task<ActionResult<GetTokensDto>> Login([FromBody] GetUserByCredentialsDto dto)
		{
			var user = await _userService.GetUserByCredentials(dto.Login, dto.Password);
			var getTokensDto = new GetTokensDto
				(

					await _jwtAuthenticationService.GetJwtAccessToken(dto.Login, dto.Password),
					_refreshTokenService.CreateRefreshToken(user.Id)
				);
			return Ok(getTokensDto);
		}

		//Регистрация нового пользователя.
		[AllowAnonymous]
		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] CreateUserDto dto)
		{
			return Ok(await _userService.CreateAsync(dto));
		}

		[AllowAnonymous]
		[HttpPost("refresh")]
		public async Task<IActionResult> Refresh([FromBody] RefreshTokenDto dto)
		{
			return Ok();
		}
	}
}