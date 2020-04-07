using System.Collections.Generic;
using System.Threading.Tasks;
using Admin.Data.Models;

namespace Admin.Common.Services
{
	public interface IPersonService
	{
		Task AddPersonAsync(Person person);
		Task<List<Person>> GetPeopleMatchingSearchTermAsync(string searchTerm);
	}
}