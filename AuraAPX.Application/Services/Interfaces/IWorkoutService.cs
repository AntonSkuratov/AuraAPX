using AuraAPX.Application.Dtos.ParameterDtos;
using AuraAPX.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuraAPX.Application.Services.Interfaces
{
	public interface IWorkoutService
	{
		Task<Guid> CreateAsync(Guid id, CreateWorkoutDto dto);
		Task<Workout> GetAsync(Guid id);
		Task<List<Workout>> GetAllWorkoutsUserAsync(Guid userId);
		Task<Guid> DeleteAsync(Guid id);
		Task<Guid?> UpdateAsync(UpdateWorkoutDto dto);
	}
}
