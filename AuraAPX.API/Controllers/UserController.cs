using AuraAPX.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AuraAPX.Application.Dtos.ParameterDtos;
using Microsoft.AspNetCore.Authorization;

namespace AuraAPX.API.Controllers
{
	[Route("users")]
	public class UserController : Controller
	{
		private readonly IUserService _userService;
		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpPost("")]
		public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
		{
			return Ok(await _userService.CreateAsync(dto));
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
			return Ok(await _userService.GetAsync(id));
		}

		//Получение профиля текущего пользователя.
		[Authorize]
		[HttpGet("me")]
		public async Task<IActionResult> GetCurrentUser()
		{
			return Ok(await _userService.GetCurrentUser(Guid.Parse(User.FindFirst("Guid-Id")!.Value)));

		}

		//Получение профиля текущего пользователя.
		[Authorize]
		[HttpGet("me/workouts")]
		public async Task<IActionResult> GetWorkoutsCurrentUser()
		{
			return Ok(await _userService.GetWorkoutsCurrentUser(Guid.Parse(User.FindFirst("Guid-Id")!.Value)));

		}

		[HttpGet("")]
		public async Task<IActionResult> GetAll(GetAllUsersDto dto)
		{
			return Ok(await _userService.GetAllAsync(dto));
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			return Ok(await _userService.DeleteAsync(id));
		}

		[HttpPut("")]
		public async Task<IActionResult> Update([FromBody] UpdateUserDto dto)
		{
			return Ok(await _userService.UpdateAsync(dto));
		}
	}
}
