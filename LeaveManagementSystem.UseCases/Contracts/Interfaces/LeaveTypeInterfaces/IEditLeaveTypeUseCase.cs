using LeaveManagementSystem.Domain;

namespace LeaveManagementSystem.UseCases.Contracts.Interfaces.LeaveTypeInterfaces
{
	public interface IEditLeaveTypeUseCase
	{
		Task<bool> ExecuteAsync(int id, LeaveType leaveType);
	}
}