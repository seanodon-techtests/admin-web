using System.Collections.Generic;
using System.Threading.Tasks;
using Admin.Data.Models;

namespace Admin.Data.Repositories
{
	public interface IGroupsRepository
	{
		Task<List<Group>> GetAllGroupsAsync();
	}
}