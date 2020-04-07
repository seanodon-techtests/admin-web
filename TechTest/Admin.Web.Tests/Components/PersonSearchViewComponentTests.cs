using Admin.Web.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Shouldly;
using Xunit;

namespace Admin.Web.Tests.Components
{
	public class PersonSearchViewComponentTests
	{
		private readonly PersonSearchViewComponent SUT;

		public PersonSearchViewComponentTests()
		{
			SUT = new PersonSearchViewComponent();
		}

		[Fact]
		public void ComponentIsInvokedCorrectly()
		{
			var result = SUT.Invoke();

			var viewResult = result.ShouldBeAssignableTo<ViewViewComponentResult>();
			viewResult.ViewName.ShouldBeNull();
		}
	}
}
