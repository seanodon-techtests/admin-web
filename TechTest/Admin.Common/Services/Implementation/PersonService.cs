using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Admin.Data.Models;
using Admin.Data.Repositories;

namespace Admin.Common.Services.Implementation
{
	public class PersonService : IPersonService
	{
		private readonly IPersonRepository _repo;

		public PersonService(IPersonRepository repo)
		{
			_repo = repo;
		}

		public async Task AddPersonAsync(Person person)
		{
			person.CreatedOn = DateTime.Today;

			await _repo.AddPersonAsync(person);
		}

		public async Task<List<Person>> GetPeopleMatchingSearchTermAsync(string searchTerm)
		{
			return await _repo.GetPeopleMatchingSearchTermAsync(searchTerm);
		}
	}
}