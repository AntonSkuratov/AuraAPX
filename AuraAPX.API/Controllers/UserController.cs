using AuraAPX.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AuraAPX.Application.Dtos.ParameterDtos;
using Microsoft.AspNetCore.Authorization;

namespace AuraAPX.API.Controllers
{
	[Route("users/me")]
	public class UserController : Controller
	{
		private readonly IUserService _userService;
		private readonly IWorkoutService _workoutService;
		public UserController(IUserService userService, IWorkoutService workoutService)
		{
			_userService = userService;
			_workoutService = workoutService;
		}

		//Регистрация нового пользователя.
		//[AllowAnonymous]
		//[HttpPost("")]
		//public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
		//{
		//	return Ok(await _userService.CreateAsync(dto));
		//}

		//Получение профиля текущего пользователя.
		[Authorize]
		[HttpGet]
		public async Task<IActionResult> GetCurrentUser()
		{
			var userId = Guid.Parse(User.FindFirst("Guid-Id")!.Value);		
			return Ok(await _userService.GetCurrentUser(userId));
		}

		//Получение списка тренировок текущего пользователя.
		//[Authorize]
		//[HttpGet("me/workouts")]
		//public async Task<IActionResult> GetWorkoutsCurrentUser()
		//{
		//	return Ok(await _userService.GetWorkoutsCurrentUser(Guid.Parse(User.FindFirst("Guid-Id")!.Value)));

		//}

		//Создание тренировки текущего пользователя.
		//[Authorize]
		//[HttpPost("me/workouts")]
		//public async Task<IActionResult> CreateWorkoutCurrentUser([FromBody] CreateWorkoutDto dto)
		//{
		//	return Ok(await _workoutService.CreateAsync(Guid.Parse(User.FindFirst("Guid-Id")!.Value), dto));
		//}

		//[Authorize]
		//[HttpDelete("me/workouts/{id}")]
		//public async Task<IActionResult> DeleteWorkoutCurrentUser(Guid id)
		//{
		//	return Ok(await _workoutService.DeleteAsync(id));
		//}

		//[HttpGet("")]
		//public async Task<IActionResult> GetAll(GetAllUsersDto dto)
		//{
		//	return Ok(await _userService.GetAllAsync(dto));
		//}

		//[Authorize]
		//[HttpDelete("me")]
		//public async Task<IActionResult> Delete([FromBody] DeleteUserDto dto)
		//{
		//	return Ok(await _userService.DeleteAsync((Guid.Parse(User.FindFirst("Guid-Id")!.Value)), dto));
		//}

		[Authorize]
		[HttpPut]
		public async Task<IActionResult> Update([FromBody] UpdateUserDto dto)
		{
			return Ok(await _userService.UpdateAsync((Guid.Parse(User.FindFirst("Guid-Id")!.Value)), dto));
		}
	}
}
