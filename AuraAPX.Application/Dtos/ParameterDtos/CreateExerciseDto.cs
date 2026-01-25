using System;
using System.Collections.Generic;
using System.Text;

namespace AuraAPX.Application.Dtos.ParameterDtos
{
	public record CreateExerciseDto
		(
		string Title,
		string Description,
		Guid WorkoutId
		);
}
