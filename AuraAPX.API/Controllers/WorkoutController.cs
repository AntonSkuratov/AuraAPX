using AuraAPX.Application.Dtos.ParameterDtos;
using AuraAPX.Application.Services;
using AuraAPX.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuraAPX.API.Controllers
{
	[Route("users/me/workouts")]
	public class WorkoutController : Controller
	{
		private readonly IWorkoutService _workoutService;
		private readonly IUserService _userService;

		public WorkoutController(IWorkoutService workoutService,
			IUserService userService)
		{
			_workoutService = workoutService;
			_userService = userService;
		}

		[HttpPost("")]
		public async Task<IActionResult> Create([FromBody] CreateWorkoutDto dto)
		{
			//todo
			return Ok();
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
			var userId = Guid.Parse(User.FindFirst("Guid-Id")!.Value);
			var user= await _userService.GetCurrentUser(userId);
			var workout=await _workoutService.GetAsync(id);
			if (user.Workouts.Contains(workout))
				return Ok(await _workoutService.GetAsync(id));
			else
				return Forbid("Нема тебе");
		}

		[HttpGet]
		public async Task<IActionResult> GetAllWorkoutsCurrentUser()
		{
			var userId = Guid.Parse(User.FindFirst("Guid-Id")!.Value);
			return Ok(await _workoutService.GetAllWorkoutsUserAsync(userId));
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			return Ok(await _workoutService.DeleteAsync(id));
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update([FromBody] UpdateWorkoutDto dto)
		{			
			return Ok(await _workoutService.UpdateAsync(dto));
		}
	}
}
