using System;
using System.Collections.Generic;
using System.Text;

namespace AuraAPX.Application.Dtos.ParameterDtos
{
	public record CreateUserDto
		(
		string Name,
		string Surname,
		string Email,
		string Login,
		string Password
		);
}
