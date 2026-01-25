using System;
using System.Collections.Generic;
using System.Text;

namespace AuraAPX.Application.Dtos.ParameterDtos
{
	public record UpdateWorkoutDto
		(
		Guid Id,
		string Title,
		string Description,
		DateTime EndTime
		);
}
