namespace LeaveManagementSystem.UseCases.Contracts.Interfaces.LeaveTypeInterfaces
{
	public interface IIsLeaveTypeExistUseCase
	{
		Task<bool> ExecuteAsync(int id);
	}
}