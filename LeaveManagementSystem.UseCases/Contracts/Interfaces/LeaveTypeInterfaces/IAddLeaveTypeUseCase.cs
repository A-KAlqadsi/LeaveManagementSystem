using LeaveManagementSystem.Domain;

namespace LeaveManagementSystem.UseCases.Contracts.Interfaces.LeaveTypeInterfaces
{
	public interface IAddLeaveTypeUseCase
	{
		Task<int> Execute(LeaveType leaveType);
	}
}