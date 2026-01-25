using AuraAPX.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuraAPX.Core.Interfaces.EntityInterfaces
{
	public interface IExerciseRepository
	{
		Task<Guid> CreateAsync(Exercise exercise);
		Task<Guid> DeleteAsync(Guid id);
		Task<Exercise> GetAsync(Guid id);
		Task<List<Exercise>> GetAllAsync();
		Task<Guid> UpdateAsync(Guid id, Exercise exercise);
	}
}
