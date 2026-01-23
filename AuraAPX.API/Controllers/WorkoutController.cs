using AuraAPX.Application.Dtos.ParameterDtos;
using AuraAPX.Application.Services;
using AuraAPX.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuraAPX.API.Controllers
{
	[Route("workouts")]
	public class WorkoutController : Controller
	{
		private readonly IWorkoutService _workoutService;
		public WorkoutController(IWorkoutService workoutService)
		{
			_workoutService = workoutService;
		}

		[HttpPost("")]
		public async Task<IActionResult> Create([FromBody] CreateWorkoutDto dto)
		{
			return Ok(await _workoutService.CreateAsync(dto));
		}
	}
}
