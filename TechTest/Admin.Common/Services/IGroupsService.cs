using System.Collections.Generic;
using System.Threading.Tasks;
using Admin.Data.Models;

namespace Admin.Common.Services
{
	public interface IGroupsService
	{
		Task<List<Group>> GetAllGroupsAsync();
	}
}