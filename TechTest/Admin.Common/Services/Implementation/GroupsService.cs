using System.Collections.Generic;
using System.Threading.Tasks;
using Admin.Data.Models;
using Admin.Data.Repositories;

namespace Admin.Common.Services.Implementation
{
	public class GroupsService : IGroupsService
	{
		private readonly IGroupsRepository _groupsRepository;

		public GroupsService(IGroupsRepository groupsRepository)
		{
			_groupsRepository = groupsRepository;
		}

		public async Task<List<Group>> GetAllGroupsAsync()
		{
			return await _groupsRepository.GetAllGroupsAsync();
		}
	}
}