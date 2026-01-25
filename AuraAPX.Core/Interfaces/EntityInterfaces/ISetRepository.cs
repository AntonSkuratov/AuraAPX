using AuraAPX.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuraAPX.Core.Interfaces.EntityInterfaces
{
	public interface ISetRepository
	{
		Task<Guid> CreateAsync(Set set);
		Task<Guid> DeleteAsync(Guid id);
		Task<Set> GetAsync(Guid id);
		Task<List<Set>> GetAllAsync();
		Task<Guid> UpdateAsync(Guid id, Set set);
	}
}
