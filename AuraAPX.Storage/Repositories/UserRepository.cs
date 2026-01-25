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
			user.UserParameters = new UserParameters
			{
				UserId = user.Id
			};
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
			return await _databaseContext.Users.Include(x => x.LocalLogin).Include(x => x.Workouts).ToListAsync();
		}

		//Получение пользователя по id.
		public async Task<User> GetAsync(Guid id)
		{
			var user = await _databaseContext.Users
				.Include(x => x.UserParameters)
				.Include(x => x.LocalLogin)
				.Include(x => x.Workouts)
				.ThenInclude(x => x.Exercises)
				.ThenInclude(x => x.Sets)
				.FirstAsync(x => x.Id == id);
			return user;
		}

		//Обновление пользователя по id.
		public async Task<Guid> UpdateAsync(Guid id, User user)
		{
			var _user = await _databaseContext.Users.Include(x => x.LocalLogin)
				.Include(x => x.UserParameters)
				.FirstAsync(x => x.Id == id);

			_user.Name = user.Name;
			_user.Surname = user.Surname;
			_user.DateBirth = user.DateBirth;

			_user.LocalLogin!.PasswordHash = user.LocalLogin!.PasswordHash;

			_user.UserParameters!.Height = user.UserParameters!.Height;
			_user.UserParameters!.Weight = user.UserParameters!.Weight;

			await _databaseContext.SaveChangesAsync();
			return _user.Id;
		}
	}
}
