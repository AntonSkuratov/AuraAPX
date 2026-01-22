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

			return await _userRepository.CreateAsync(user);
		}
	}
}
