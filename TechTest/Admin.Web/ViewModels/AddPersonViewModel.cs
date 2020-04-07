using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Admin.Web.ViewModels
{
	public class AddPersonViewModel
	{
		[DisplayName("First Name")]
		[Required]
		[StringLength(64, MinimumLength = 1)]
		public string FirstName { get; set; }
		
		[DisplayName("Last Name")]
		[Required]
		[StringLength(64, MinimumLength = 1)]
		public string LastName { get; set; }
		
		[DisplayName("Group")]
		[Required]
		public Guid GroupId { get; set; }
	}
}