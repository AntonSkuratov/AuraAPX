using AuraAPX.Application.Dtos.ParameterDtos;
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
		Task<List<User>> GetAllAsync(GetAllUsersDto dto);
		Task<Guid> DeleteAsync(Guid id)	;
	}
}
