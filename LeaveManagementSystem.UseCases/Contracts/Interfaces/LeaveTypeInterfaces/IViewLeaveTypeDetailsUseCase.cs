using LeaveManagementSystem.Domain;

namespace LeaveManagementSystem.UseCases.Contracts.Interfaces.LeaveTypeInterfaces
{
	public interface IViewLeaveTypeDetailsUseCase
	{
		Task<LeaveType?> ExecuteAsync(int id);
	}
}