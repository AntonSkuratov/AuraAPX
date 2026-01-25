using AuraAPX.Application.Dtos.ParameterDtos;
using AuraAPX.Application.Services.Interfaces;
using AuraAPX.Core.Entities;
using AuraAPX.Core.Interfaces.EntityInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuraAPX.Application.Services
{
	public class ExerciseService : IExerciseService
	{
		private readonly IExerciseRepository _exerciseRepository;
		public ExerciseService(IExerciseRepository exerciseRepository)
		{
			_exerciseRepository = exerciseRepository;
		}


		public async Task<Guid> CreateAsync(CreateExerciseDto dto)
		{
			var exercise = new Exercise
			{
				Title = dto.Title,
				Description = dto.Description,
				WorkoutId = dto.WorkoutId,
			};

			return await _exerciseRepository.CreateAsync(exercise);
		}
	}
}
