using AuraAPX.Application.Dtos.ParameterDtos;
using AuraAPX.Application.Dtos.ReturnedDtos;
using AuraAPX.Application.Services.Interfaces;
using AuraAPX.Core.Entities;
using AuraAPX.Core.Interfaces;
using AuraAPX.Core.Interfaces.EntityInterfaces;
using AuraAPX.Storage;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Text;

namespace AuraAPX.Application.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IPasswordProvider _passwordProvider;

		public UserService(IUserRepository userRepository, IPasswordProvider passwordProvider)
		{
			_userRepository = userRepository;
			_passwordProvider = passwordProvider;
		}

		//Создание пользователя.
		public async Task<Guid> CreateAsync(CreateUserDto dto)
		{
			var localLogin = new LocalLogin
			{
				Login = dto.Login,
				PasswordHash = _passwordProvider.GenerateHash(dto.Password)
			};

			var user = new User
			{
				Name = dto.Name,
				Surname = dto.Surname,
				Email = dto.Email,
			};
			user.LocalLogin = localLogin;
			user.UserParameters = new UserParameters();

			return await _userRepository.CreateAsync(user);
		}

		//Удаление пользователся по id.
		public async Task<Guid> DeleteAsync(Guid id, DeleteUserDto dto)
		{
			var user = await GetUserByCredentials(dto.Login, dto.Password);
			if (user.Id == id)
				return await _userRepository.DeleteAsync(id);
			else
				throw new AuthenticationException("Неверный логин или пароль");
		}

		////Получение всех пользователей.
		//public async Task<List<User>> GetAllAsync(GetAllUsersDto dto)
		//{
		//	var users = await _userRepository.GetAllAsync();

		//	if (string.IsNullOrWhiteSpace(dto.SearchString))
		//		return users;

		//	return users.Where(x => x.Name!.Contains(dto.SearchString)
		//		|| x.Surname!.Contains(dto.SearchString))
		//		.ToList();
		//}

		//Получение пользователся по id.
		public async Task<User> GetAsync(Guid id)
		{
			return await _userRepository.GetAsync(id);
		}

		public async Task<User> GetCurrentUser(Guid id)
		{
			var user = await _userRepository.GetAsync(id);

			//var userDto = new GetCurrentUserDto(
			//	user.Id,
			//	user.Name!, user.Surname!,
			//	user.Email!, user.DateBirth,
			//	user.UserParameters!.Gender!, user.UserParameters.Height, user.UserParameters.Weight,
			//	user.LocalLogin!.Login!,
			//	user.Workouts.Count()
			//	);

			return user;
		}

		public async Task<User> GetUserByCredentials(string login, string password)
		{
			var users = await _userRepository.GetAllAsync();

			var hash = users.First(x => x.LocalLogin!.Login == login).LocalLogin!.PasswordHash;
			var user = users.First(x => x.LocalLogin!.Login == login && _passwordProvider.VerifyPassword(password, hash!));

			return user;
		}

		public async Task<List<GetWorkoutsCurrentUserDto>> GetWorkoutsCurrentUser(Guid id)
		{
			var user = await _userRepository.GetAsync(id);
			var workouts = user.Workouts;

			var workoutsDto = workouts.Select(x => new GetWorkoutsCurrentUserDto
				(
				x.Title!,
				x.Description!,
				x.StartTime,
				x.EndTime,
				x.Exercises.Count()
				));

			return workoutsDto.ToList();
		}

		//Обновление пользователся по id.
		public async Task<Guid> UpdateAsync(Guid id, UpdateUserDto dto)
		{
			var newUser = new User
			{
				Name = dto.Name,
				Surname = dto.Surname,
				DateBirth = dto.DateBirth
			};

			var newUserParameters = new UserParameters
			{
				Height = dto.Height,
				Weight = dto.Weight,
			};

			newUser.UserParameters = newUserParameters;

			return await _userRepository.UpdateAsync(id, newUser);
		}
	}
}
