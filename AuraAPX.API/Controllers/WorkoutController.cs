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
			//todo
			return Ok();
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
			return Ok(await _workoutService.GetAsync(id));
		}

		[HttpGet("")]
		public async Task<IActionResult> GetAll(GetAllWorkoutsDto dto)
		{
			return Ok(await _workoutService.GetAllAsync(dto));
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			return Ok(await _workoutService.DeleteAsync(id));
		}

		[HttpPut("")]
		public async Task<IActionResult> Update([FromBody] UpdateWorkoutDto dto)
		{
			return Ok(await _workoutService.UpdateAsync(dto));
		}
	}
}
