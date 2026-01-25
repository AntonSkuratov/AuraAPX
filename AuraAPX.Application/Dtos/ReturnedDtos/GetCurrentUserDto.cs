using System;
using System.Collections.Generic;
using System.Text;

namespace AuraAPX.Application.Dtos.ReturnedDtos
{
	public record GetCurrentUserDto
		(
		Guid Id,
		string Name,
		string Surname,
		string Email,
		DateTime DateBirth,
		string Gender,
		int Height,
		int Weight,
		string Login,
		int CountWorkouts
		);
}
