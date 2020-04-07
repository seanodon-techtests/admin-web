using System;
using System.Linq;
using System.Threading.Tasks;
using Admin.Common.Services.Implementation;
using Admin.Data.Models;
using Admin.Data.Repositories;
using AutoFixture;
using Moq;
using Shouldly;
using Xunit;

namespace Admin.Common.Tests.Services
{
	public class PersonServiceTests
	{
		private readonly Mock<IPersonRepository> _mockRepository;
		private readonly PersonService SUT;
		private readonly Fixture _fixture;

		public PersonServiceTests()
		{
			_fixture = new Fixture();
			_fixture.Behaviors.Add(new OmitOnRecursionBehavior());
			_mockRepository = new Mock<IPersonRepository>();
			SUT = new PersonService(_mockRepository.Object);
		}

		[Fact]
		public async Task AddPerson_CallsRepositoryCorrectly()
		{
			var person = new Person();

			await SUT.AddPersonAsync(person);

			_mockRepository.Verify(repo => repo.AddPersonAsync(person), Times.Once);
		}

		[Fact]
		public async Task AddPerson_CreatedOn_SetCorrectly()
		{
			var person = new Person();

			await SUT.AddPersonAsync(person);

			person.CreatedOn.ShouldBe(DateTime.Today);
		}

		[Fact]
		public async Task GetPeopleMatchingSearchTerm_CallsRepositoryCorrectly()
		{
			var matchingPeople = _fixture.CreateMany<Person>(5).ToList();
			_mockRepository.Setup(repo => repo.GetPeopleMatchingSearchTermAsync(It.IsAny<string>()))
				.ReturnsAsync(matchingPeople);
			var searchTerm = "Adm";

			var result = await SUT.GetPeopleMatchingSearchTermAsync(searchTerm);

			_mockRepository.Verify(repo => repo.GetPeopleMatchingSearchTermAsync(searchTerm), Times.Once);
			result.ShouldBe(matchingPeople);
		}
	}
}
