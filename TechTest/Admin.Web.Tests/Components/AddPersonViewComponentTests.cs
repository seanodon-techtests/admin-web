using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Common.Services;
using Admin.Data.Models;
using Admin.Web.ViewComponents;
using Admin.Web.ViewModels;
using AutoFixture;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using Shouldly;
using Xunit;

namespace Admin.Web.Tests.Components
{
	public class AddPersonViewComponentTests
	{
		private readonly Mock<IGroupsService> _mockGroupsService;
		private readonly Mock<IMapper> _mockMapper;
		private readonly Fixture _fixture;
		private readonly AddPersonViewComponent SUT;

		public AddPersonViewComponentTests()
		{
			_fixture = new Fixture();
			_fixture.Behaviors.Add(new OmitOnRecursionBehavior());
			_mockGroupsService = new Mock<IGroupsService>();
			_mockMapper = new Mock<IMapper>();
			SUT = new AddPersonViewComponent(_mockGroupsService.Object, _mockMapper.Object);
		}

		[Fact]
		public async Task ComponentIsInvokedCorrectly()
		{
			var groups = _fixture.CreateMany<Group>(5).ToList();
			_mockGroupsService.Setup(svc => svc.GetAllGroupsAsync())
				.ReturnsAsync(groups);

			var mappedResponse = _fixture.CreateMany<GroupViewModel>(5).ToList();
			_mockMapper.Setup(m => m.Map<List<GroupViewModel>>(It.IsAny<List<Group>>()))
				.Returns(mappedResponse);
			
			var result = await SUT.InvokeAsync();
			
			_mockGroupsService.Verify(svc => svc.GetAllGroupsAsync(), Times.Once);
			_mockMapper.Verify(m => m.Map<List<GroupViewModel>>(groups), Times.Once);
			
			var viewResult = result.ShouldBeAssignableTo<ViewViewComponentResult>();
			viewResult.ViewName.ShouldBeNull();
			viewResult.ViewData["Groups"].ShouldBe(mappedResponse);
		}
	}
}
