using AuraAPX.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AuraAPX.Application.Dtos.ParameterDtos;

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
	}
}
