using System.Collections.Generic;
using System.Threading.Tasks;
using Admin.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Admin.Data.Repositories.Implementation
{
	public class GroupsRepository : IGroupsRepository
	{
		private readonly AdminContext _dbContext;

		public GroupsRepository(AdminContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<List<Group>> GetAllGroupsAsync()
		{
			return await _dbContext.Groups.AsNoTracking().ToListAsync();
		}
	}
}