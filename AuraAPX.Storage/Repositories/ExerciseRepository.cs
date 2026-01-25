using AuraAPX.Core.Entities;
using AuraAPX.Core.Interfaces.EntityInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuraAPX.Storage.Repositories
{
	public class ExerciseRepository : IExerciseRepository
	{
		private readonly DatabaseContext _databaseContext;

		public ExerciseRepository(DatabaseContext databaseContext)
		{
			_databaseContext = databaseContext;
		}


		public async Task<Guid> CreateAsync(Exercise exercise)
		{
			await _databaseContext.Exercises.AddAsync(exercise);		
			await _databaseContext.SaveChangesAsync();
			return exercise.Id;
		}

		public async Task<Guid> DeleteAsync(Guid id)
		{
			var exercise = await _databaseContext.Exercises.FirstAsync(x => x.Id == id);
			_databaseContext.Exercises.Remove(exercise);
			await _databaseContext.SaveChangesAsync();
			return id;
		}

		public async Task<List<Exercise>> GetAllAsync()
		{
			return await _databaseContext.Exercises.Include(x => x.Sets).ToListAsync();
		}

		public async Task<Exercise> GetAsync(Guid id)
		{
			var exercise = await _databaseContext.Exercises.Include(x=>x.Sets).FirstAsync(x => x.Id == id);
			return exercise;
		}

		public async Task<Guid> UpdateAsync(Guid id, Exercise exercise)
		{
			var _exercise = await _databaseContext.Exercises.FirstAsync(x => x.Id == id);

			_exercise.Title = exercise.Title;
			_exercise.Description = exercise.Description;

			await _databaseContext.SaveChangesAsync();
			return _exercise.Id;
		}
	}
}
