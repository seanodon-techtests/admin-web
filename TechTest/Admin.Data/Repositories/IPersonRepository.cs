using System.Collections.Generic;
using System.Threading.Tasks;
using Admin.Data.Models;

namespace Admin.Data.Repositories
{
	public interface IPersonRepository
	{
		Task AddPersonAsync(Person person);
		Task<List<Person>> GetPeopleMatchingSearchTermAsync(string searchTerm);
	}
}