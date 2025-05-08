using LeaveManagementSystem.Domain.Common;

namespace LeaveManagementSystem.Domain
{
	public class LeaveType : BaseEntity
	{
		public string Name { get; set; }
		public int NumberOfDays { get; set; }

	}
}
