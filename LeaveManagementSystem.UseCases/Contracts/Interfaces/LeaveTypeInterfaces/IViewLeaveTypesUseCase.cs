using LeaveManagementSystem.Domain;

namespace LeaveManagementSystem.UseCases.Contracts.Interfaces.LeaveTypeInterfaces
{
	public interface IViewLeaveTypesUseCase
	{
		Task<IReadOnlyList<LeaveType>> ExecuteAsync();
	}
}