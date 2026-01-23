using AuraAPX.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuraAPX.Core.Interfaces.EntityInterfaces
{
	public interface IWorkoutRepository
	{
		Task<Guid> CreateAsync(Workout workout);
		Task<Guid> DeleteAsync(Guid id);
		Task<Workout> GetAsync(Guid id);
		Task<List<Workout>> GetAllAsync();
		Task<Guid> UpdateAsync(Guid id, Workout workout);
	}
}
