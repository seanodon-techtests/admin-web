using System.Collections.Generic;
using System.Threading.Tasks;
using Admin.Common.Services;
using Admin.Data.Models;
using Admin.Web.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Web.Controllers
{
	public class PersonController : Controller
	{
		private readonly IPersonService _personService;
		private readonly IMapper _mapper;

		public PersonController(IPersonService personService, IMapper mapper)
		{
			_personService = personService;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> Search(PersonSearchModel searchModel)
		{
			var peopleMatchingSearchTerm = await _personService.GetPeopleMatchingSearchTermAsync(searchModel.SearchTerm);
			var viewModel = _mapper.Map<List<PersonViewModel>>(peopleMatchingSearchTerm);
			return PartialView("_List", viewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Add(AddPersonViewModel viewModel)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			var person = _mapper.Map<Person>(viewModel);
			await _personService.AddPersonAsync(person);

			return Ok();
		}
	}
}