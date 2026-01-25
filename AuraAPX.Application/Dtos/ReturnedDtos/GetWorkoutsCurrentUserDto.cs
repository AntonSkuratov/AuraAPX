using System;
using System.Collections.Generic;
using System.Text;

namespace AuraAPX.Application.Dtos.ReturnedDtos
{
	public record GetWorkoutsCurrentUserDto
		(
		string Title,
		string Description,
		DateTime StartTime,
		DateTime EndTime,
		int CountExercises
		);
}
