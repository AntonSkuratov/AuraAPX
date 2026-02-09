using AuraAPX.API.Authentication.Dtos.ParameterDtos;
using AuraAPX.API.Authentication.Dtos.ReturnedDtos;
using AuraAPX.API.Authentication.Services.Interfaces;
using AuraAPX.Application.Dtos.ParameterDtos;
using AuraAPX.Application.Services.Interfaces;
using AuraAPX.Core.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuraAPX.API.Controllers
{
	[AllowAnonymous]
	[Route("auth")]
	public class AuthenticationController : Controller
	{
		private readonly IJwtAuthenticationService _jwtAuthenticationService;
		private readonly IRefreshTokenService _refreshTokenService;
		private readonly IUserService _userService;
		private readonly IValidator<CreateUserDto> _validator;
		public AuthenticationController(IJwtAuthenticationService jwtAuthenticationService, 
			IUserService userService, 
			IRefreshTokenService refreshTokenService,
			IValidator<CreateUserDto> validator)
		{
			_jwtAuthenticationService = jwtAuthenticationService;
			_userService = userService;
			_refreshTokenService = refreshTokenService;
			_validator = validator;
		}


		//Получение access-токена по логину и паролю.
		[HttpPost("login")]
		public async Task<ActionResult<GetTokensDto>> Login([FromBody] GetUserByCredentialsDto dto)
		{
			var user = await _userService.GetUserByCredentials(dto.Login, dto.Password);
			var getTokensDto = new GetTokensDto
				(
					user.Id,
					await _jwtAuthenticationService.GetJwtAccessToken(dto.Login, dto.Password),
					_refreshTokenService.CreateRefreshToken(user.Id)
				);
			return Ok(getTokensDto);
		}

		//Регистрация нового пользователя.
		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] CreateUserDto dto)
		{
			var validationResult = await _validator.ValidateAsync(dto);
			if (!validationResult.IsValid)
			{
				return BadRequest(validationResult.Errors);
			}
			var userId = await _userService.CreateAsync(dto);
			_refreshTokenService.CreateRefreshToken(userId);
			return Ok(userId);
		}

		[HttpPost("refresh")]
		public async Task<IActionResult> Refresh([FromBody] RefreshTokenDto dto)
		{
			return Ok();
		}
	}
}