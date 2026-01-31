using AuraAPX.Application.Dtos.ParameterDtos;
using AuraAPX.Application.Services.Interfaces;
using AuraAPX.Core.Entities;
using AuraAPX.Core.Features;
using AuraAPX.Core.Interfaces;
using AuraAPX.Core.Interfaces.EntityInterfaces;
using AuraAPX.Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuraAPX.Application.Services
{
	public class WorkoutService : IWorkoutService
	{
		private readonly IWorkoutRepository _workoutRepository;
		public WorkoutService(IWorkoutRepository workoutRepository)
		{
			_workoutRepository = workoutRepository;
		}


		public async Task<Guid> CreateAsync(Guid id, CreateWorkoutDto dto)
		{
			var workout = new Workout
			{
				Title = dto.Title,
				Description = dto.Description,
				UserId = id
			};

			return await _workoutRepository.CreateAsync(workout);
		}

		public Task<Guid> DeleteAsync(Guid id)
		{
			return _workoutRepository.DeleteAsync(id);
		}

		public async Task<List<Workout>> GetAllAsync(GetAllWorkoutsDto dto)
		{
			var workouts = await _workoutRepository.GetAllAsync();

			if (string.IsNullOrWhiteSpace(dto.SearchString))
				return workouts;

			return workouts.Where(x => x.Title!.Contains(dto.SearchString)
				|| x.Description!.Contains(dto.SearchString))
				.ToList();
		}

		public async Task<Workout> GetAsync(Guid id)
		{
			return await _workoutRepository.GetAsync(id);
		}

		public async Task<Guid?> UpdateAsync(UpdateWorkoutDto dto)
		{
			var newWorkout = new Workout
			{
				Title = dto.Title,
				Description = dto.Description,
				EndTime = dto.EndTime
			};

			return await _workoutRepository.UpdateAsync(dto.Id, newWorkout);
		}
	}
}
