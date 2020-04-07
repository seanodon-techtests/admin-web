using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Admin.Web.ViewModels
{
	public class PersonViewModel
	{
		[DisplayName("First Name")]
		public string FirstName { get; set; }
		
		[DisplayName("Last Name")]
		public string LastName { get; set; }
		
		[DisplayName("Created On")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
		public DateTime CreatedOn { get; set; }
		
		[DisplayName("Group")]
		public string Group { get; set; }
  }
}