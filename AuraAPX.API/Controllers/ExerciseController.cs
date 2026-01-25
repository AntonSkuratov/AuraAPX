using AuraAPX.Application.Dtos.ParameterDtos;
using AuraAPX.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuraAPX.API.Controllers
{
	[Route("exercises")]
	public class ExerciseController : Controller
	{
		private readonly IExerciseService _exerciseService;
		public ExerciseController(IExerciseService exerciseService)
		{
			_exerciseService = exerciseService;
		}

		[HttpPost("")]
		public async Task<IActionResult> Create([FromBody] CreateExerciseDto dto)
		{
			return Ok(await _exerciseService.CreateAsync(dto));
		}
	}
}
