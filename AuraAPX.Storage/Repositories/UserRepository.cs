using AuraAPX.Core.Entities;
using AuraAPX.Core.Interfaces;
using AuraAPX.Core.Interfaces.EntityInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuraAPX.Storage.Repositories
{

	public class UserRepository : IUserRepository
	{
		private readonly DatabaseContext _databaseContext;

		public UserRepository(DatabaseContext databaseContext)
		{
			_databaseContext = databaseContext;
		}

		//Создание пользователя.
		public async Task<Guid> CreateAsync(User user)
		{
			await _databaseContext.Users.AddAsync(user);
			await _databaseContext.SaveChangesAsync();
			return user.Id;
		}

		//Удаление пользователя по id.
		public async Task<Guid> DeleteAsync(Guid id)
		{
			var user = await _databaseContext.Users.FirstAsync(x => x.Id == id);
			_databaseContext.Users.Remove(user);
			await _databaseContext.SaveChangesAsync();
			return id;
		}

		//Получение всех пользователей.
		public async Task<List<User>> GetAllAsync()
		{
			return await _databaseContext.Users.ToListAsync();
		}

		//Получение пользователя по id.
		public async Task<User> GetAsync(Guid id)
		{
			var user = await _databaseContext.Users.FirstAsync(x => x.Id == id);
			return user;
		}

		//Обновление пользователя по id.
		public async Task<Guid> UpdateAsync(Guid id, User user)
		{
			var _user = await _databaseContext.Users.FirstAsync(x => x.Id == id);

			Guid LocalLoginId=_user.Id;
			Guid UserParametersId = _user.Id;

			_user.Name = user.Name;
			_user.Surname = user.Surname;
			_user.Email = user.Email;
			_user.DateBirth = user.DateBirth;
			_user.LocalLogin = user.LocalLogin;
			_user.UserParameters = user.UserParameters;
			_user.LocalLogin!.Id= LocalLoginId;
			_user.UserParameters!.Id = UserParametersId;

			await _databaseContext.SaveChangesAsync();
			return _user.Id;
		}
	}
}
