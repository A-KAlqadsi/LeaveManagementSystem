using Microsoft.AspNetCore.Identity;

namespace LeaveManagementSystem.Web.Data
{
	public class ApplicationUser : IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateOnly DateOfBirht { get; set; }
	}
}
