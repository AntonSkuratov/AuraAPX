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


		public async Task<Guid> CreateAsync(CreateWorkoutDto dto)
		{
			var workout = new Workout
			{
				Title = dto.Title,
				Description = dto.Description,
				UserId = dto.UserId,
			};

			return await _workoutRepository.CreateAsync(workout);
		}
	}
}
