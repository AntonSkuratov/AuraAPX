using AuraAPX.Application.Dtos.ParameterDtos;
using AuraAPX.Application.Services.Interfaces;
using AuraAPX.Core.Entities;
using AuraAPX.Core.Interfaces;
using AuraAPX.Core.Interfaces.EntityInterfaces;
using AuraAPX.Storage;
using System;
using System.Collections.Generic;
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
		public async Task<Guid> DeleteAsync(Guid id)
		{
			return await _userRepository.DeleteAsync(id);
		}

		//Получение всех пользователей.
		public async Task<List<User>> GetAllAsync(GetAllUsersDto dto)
		{
			var users = await _userRepository.GetAllAsync();

			if (string.IsNullOrWhiteSpace(dto.SearchString))
				return users;

			return users.Where(x => x.Name!.Contains(dto.SearchString)
				|| x.Surname!.Contains(dto.SearchString))
				.ToList();
		}

		//Получение пользователся по id.
		public async Task<User> GetAsync(Guid id)
		{
			return await _userRepository.GetAsync(id);
		}

		public async Task<Guid> UpdateAsync(UpdateUserDto dto)
		{
			var newUser = new User
			{
				Name = dto.Name,
				Surname = dto.Surname,
				DateBirth = dto.DateBirth
			};

			var newLocalLogin = new LocalLogin
			{
				PasswordHash = _passwordProvider.GenerateHash(dto.Password)
			};

			var newUserParameters = new UserParameters
			{
				Height = dto.Height,
				Weight = dto.Weight,
			};
			
			newUser.LocalLogin= newLocalLogin;
			newUser.UserParameters= newUserParameters;

			return await _userRepository.UpdateAsync(dto.Id, newUser);
		}
	}
}
