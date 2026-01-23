using AuraAPX.Application.Dtos.ParameterDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuraAPX.Application.Services.Interfaces
{
	public interface IWorkoutService
	{
		Task<Guid> CreateAsync(CreateWorkoutDto dto);
	}
}
