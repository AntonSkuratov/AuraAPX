using AuraAPX.Application.Dtos.ParameterDtos;
using AuraAPX.Application.Dtos.ReturnedDtos;
using AuraAPX.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuraAPX.Application.Services.Interfaces
{
	public interface IUserService
	{
		Task<Guid> CreateAsync(CreateUserDto dto);
		Task<User> GetAsync(Guid id);
		//Task<List<User>> GetAllAsync(GetAllUsersDto dto);
		Task<Guid> DeleteAsync(Guid id, DeleteUserDto dto);
		Task<Guid> UpdateAsync(Guid id, UpdateUserDto dto);
		Task<GetCurrentUserDto> GetCurrentUser(Guid id);
		Task<List<GetWorkoutsCurrentUserDto>> GetWorkoutsCurrentUser(Guid id);
		Task<User> GetUserByCredentials(string login, string password);
	}
}
