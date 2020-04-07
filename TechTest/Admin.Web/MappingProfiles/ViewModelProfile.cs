using Admin.Data.Models;
using Admin.Web.ViewModels;
using AutoMapper;

namespace Admin.Web.MappingProfiles
{
	public class ViewModelProfile : Profile
	{
		public ViewModelProfile()
		{
			CreateMap<AddPersonViewModel, Person>();
			CreateMap<GroupViewModel, Group>().ReverseMap();
			CreateMap<Person, PersonViewModel>()
				.ForMember(dest => dest.Group, opt => opt.MapFrom(src => src.Group.Name));
		}
	}
}
