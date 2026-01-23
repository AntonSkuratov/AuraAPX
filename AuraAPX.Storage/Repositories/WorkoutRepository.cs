using AuraAPX.Core.Entities;
using AuraAPX.Core.Interfaces.EntityInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuraAPX.Storage.Repositories
{
	public class WorkoutRepository : IWorkoutRepository
	{
		private readonly DatabaseContext _databaseContext;

		public WorkoutRepository(DatabaseContext databaseContext)
		{
			_databaseContext = databaseContext;
		}

		public async Task<Guid> CreateAsync(Workout workout)
		{
			await _databaseContext.Workouts.AddAsync(workout);
			await _databaseContext.SaveChangesAsync();
			return workout.Id;
		}

		public async Task<Guid> DeleteAsync(Guid id)
		{
			var workout = await _databaseContext.Workouts.FirstAsync(x => x.Id == id);
			_databaseContext.Workouts.Remove(workout);
			await _databaseContext.SaveChangesAsync();
			return id;
		}

		public async Task<List<Workout>> GetAllAsync()
		{
			return await _databaseContext.Workouts.ToListAsync();
		}

		public async Task<Workout> GetAsync(Guid id)
		{
			var workout = await _databaseContext.Workouts.FirstAsync(x => x.Id == id);
			return workout;
		}

		public async Task<Guid> UpdateAsync(Guid id, Workout workout)
		{
			var _workout = await _databaseContext.Workouts.FirstAsync(x => x.Id == id);

			_workout.Title = workout.Title;
			_workout.Description = workout.Description;
			_workout.EndTime = workout.EndTime;

			await _databaseContext.SaveChangesAsync();
			return _workout.Id;
		}
	}
}
