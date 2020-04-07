using Microsoft.AspNetCore.Mvc;

namespace Admin.Web.ViewComponents
{
	public class PersonSearchViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
