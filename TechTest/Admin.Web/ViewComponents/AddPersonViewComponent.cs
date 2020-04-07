using System.Collections.Generic;
using System.Threading.Tasks;
using Admin.Common.Services;
using Admin.Web.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Web.ViewComponents
{
	public class AddPersonViewComponent : ViewComponent
	{
		private readonly IGroupsService _groupsService;
		private readonly IMapper _mapper;

		public AddPersonViewComponent(IGroupsService groupsService, IMapper mapper)
		{
			_groupsService = groupsService;
			_mapper = mapper;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var groups = await _groupsService.GetAllGroupsAsync();
			ViewBag.Groups = _mapper.Map<List<GroupViewModel>>(groups);

			return View();
		}
	}
}
