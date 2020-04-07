using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Common.Services;
using Admin.Data.Models;
using Admin.Web.Controllers;
using Admin.Web.ViewModels;
using AutoFixture;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using Xunit;

namespace Admin.Web.Tests.Controllers
{
	public class PersonControllerTests
	{
		private readonly Mock<IPersonService> _mockService;
		private readonly Mock<IMapper> _mockMapper;
		private readonly Fixture _fixture;
		private readonly PersonController SUT;

		public PersonControllerTests()
		{
			_fixture = new Fixture();
			_fixture.Behaviors.Add(new OmitOnRecursionBehavior());
			_mockService = new Mock<IPersonService>();
			_mockMapper = new Mock<IMapper>();
			SUT = new PersonController(_mockService.Object, _mockMapper.Object);
		}

		[Fact]
		public async Task Search_CallsServiceCorrectly()
		{
			var matchingPeople = _fixture.CreateMany<Person>(5).ToList();
			_mockService.Setup(svc => svc.GetPeopleMatchingSearchTermAsync(It.IsAny<string>()))
				.ReturnsAsync(matchingPeople);

			var mappedResponse = _fixture.CreateMany<PersonViewModel>(5).ToList();
			_mockMapper
				.Setup(m => m.Map<List<PersonViewModel>>(It.IsAny<List<Person>>()))
				.Returns(mappedResponse);

			var searchModel = new PersonSearchModel
			{
				SearchTerm = "Adm"
			};
			
			var result = await SUT.Search(searchModel);

			_mockService.Verify(svc => svc.GetPeopleMatchingSearchTermAsync(searchModel.SearchTerm), Times.Once);
			_mockMapper.Verify(m => m.Map<List<PersonViewModel>>(matchingPeople), Times.Once);
			
			var partialViewResult = result.ShouldBeAssignableTo<PartialViewResult>();
			partialViewResult.Model.ShouldBe(mappedResponse);
			partialViewResult.ViewName.ShouldBe("_List");
		}

		[Fact]
		public async Task Add_CallsServiceCorrectly_WithValidModel()
		{
			var newPerson = _fixture.Create<AddPersonViewModel>();
			var personEntity = _fixture.Create<Person>();
			_mockMapper
				.Setup(m => m.Map<Person>(It.IsAny<AddPersonViewModel>()))
				.Returns(personEntity);

			var result = await SUT.Add(newPerson);

			_mockMapper.Verify(m => m.Map<Person>(newPerson), Times.Once);
			_mockService.Verify(svc => svc.AddPersonAsync(personEntity), Times.Once);
			result.ShouldBeAssignableTo<OkResult>();
		}

		[Fact]
		public async Task AddPerson_WithInvalidModel()
		{
			var newPerson = new AddPersonViewModel();
			SUT.ModelState.AddModelError("DummyModelError", "Model error for testing purposes");

			var result = await SUT.Add(newPerson);

			_mockMapper.Verify(m => m.Map<Person>(It.IsAny<AddPersonViewModel>()), Times.Never);
			_mockService.Verify(svc => svc.AddPersonAsync(It.IsAny<Person>()), Times.Never);
			result.ShouldBeAssignableTo<BadRequestResult>();
		}
	}
}
