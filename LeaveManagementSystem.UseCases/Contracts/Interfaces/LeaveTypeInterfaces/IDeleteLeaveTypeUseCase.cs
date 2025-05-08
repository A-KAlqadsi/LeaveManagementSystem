
namespace LeaveManagementSystem.UseCases.Contracts.Interfaces.LeaveTypeInterfaces
{
	public interface IDeleteLeaveTypeUseCase
	{
		Task<bool> ExecuteAsync(int id);
	}
}
