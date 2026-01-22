using AuraAPX.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuraAPX.Core.Interfaces.EntityInterfaces
{
	public interface IUserRepository
	{
		Task<Guid> CreateAsync(User user);
		Task<Guid> DeleteAsync(Guid id);
		Task<User> GetAsync(Guid id);
		Task<List<User>> GetAllAsync();
		Task<Guid> UpdateAsync(Guid id, User user);
	}
}
