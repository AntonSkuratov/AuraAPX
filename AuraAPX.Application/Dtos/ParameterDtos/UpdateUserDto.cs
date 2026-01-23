using System;
using System.Collections.Generic;
using System.Text;

namespace AuraAPX.Application.Dtos.ParameterDtos
{
	public record UpdateUserDto
		(
		Guid Id,
		string Name,
		string Surname,
		DateTime DateBirth,
		string Password,
		int Height,
		int Weight
		);
}
