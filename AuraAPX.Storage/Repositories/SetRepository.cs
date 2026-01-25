using AuraAPX.Core.Entities;
using AuraAPX.Core.Interfaces.EntityInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuraAPX.Storage.Repositories
{
	public class SetRepository : ISetRepository
	{
		private readonly DatabaseContext _databaseContext;

		public SetRepository(DatabaseContext databaseContext)
		{
			_databaseContext = databaseContext;
		}


		public async Task<Guid> CreateAsync(Set set)
		{
			await _databaseContext.Sets.AddAsync(set);
			await _databaseContext.SaveChangesAsync();
			return set.Id;
		}

		public async Task<Guid> DeleteAsync(Guid id)
		{
			var set = await _databaseContext.Sets.FirstAsync(x => x.Id == id);
			_databaseContext.Sets.Remove(set);
			await _databaseContext.SaveChangesAsync();
			return id;
		}

		public async Task<List<Set>> GetAllAsync()
		{
			return await _databaseContext.Sets.ToListAsync();
		}

		public async Task<Set> GetAsync(Guid id)
		{
			var set = await _databaseContext.Sets.FirstAsync(x => x.Id == id);
			return set;
		}

		public async Task<Guid> UpdateAsync(Guid id, Set set)
		{
			var _set = await _databaseContext.Sets.FirstAsync(x => x.Id == id);

			_set.NumberRepetitions = set.NumberRepetitions;
			_set.WorkingWeightOrResistance = set.WorkingWeightOrResistance;
			_set.RestTime = set.RestTime;

			await _databaseContext.SaveChangesAsync();
			return _set.Id;
		}
	}
}
