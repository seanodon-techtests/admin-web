using System;
using System.Collections.Generic;
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
	public class GroupsServiceTests
	{
		private readonly Mock<IGroupsRepository> _mockRepository;
		private readonly Fixture _fixture;
		private readonly GroupsService SUT;

		public GroupsServiceTests()
		{
			_fixture = new Fixture();
			_fixture.Behaviors.Add(new OmitOnRecursionBehavior());
			_mockRepository = new Mock<IGroupsRepository>();
			SUT = new GroupsService(_mockRepository.Object);
		}

		[Fact]
		public async Task GetAllGroupsAsync_CallsRepositoryCorrectly()
		{
			var groups = _fixture.CreateMany<Group>(5).ToList();
			_mockRepository.Setup(repo => repo.GetAllGroupsAsync())
				.ReturnsAsync(groups);

			var result = await SUT.GetAllGroupsAsync();

			_mockRepository.Verify(repo => repo.GetAllGroupsAsync(), Times.Once);
			result.ShouldBe(groups);
		}
	}
}
