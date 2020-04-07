using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Admin.Data.Repositories.Implementation
{
	public class PersonRepository : IPersonRepository
	{
		private readonly AdminContext _dbContext;

		public PersonRepository(AdminContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddPersonAsync(Person person)
		{
			_dbContext.People.Add(person);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<List<Person>> GetPeopleMatchingSearchTermAsync(string searchTerm)
		{
			return await _dbContext.People.AsNoTracking()
				.Include(p => p.Group)
				.Where(p => 
					EF.Functions.Like(p.LastName, $"%{searchTerm}%") ||
					EF.Functions.Like(p.FirstName, $"%{searchTerm}%") ||
					EF.Functions.Like(p.Group.Name, $"%{searchTerm}%"))
				.OrderBy(p => p.LastName)
				.ThenBy(p => p.FirstName)
				.ToListAsync();
		}
	}
}