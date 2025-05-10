using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Models.LeaveTypes
{
	public class LeaveTypeReadOnlyVM : BaseLeaveTypeVM
	{
		public string Name { get; set; } = string.Empty;
		[Display(Name = "Maximum allocation Days")]
		public int NumberOfDays { get; set; }
	}
}
