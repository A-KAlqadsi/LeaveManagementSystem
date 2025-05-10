namespace LeaveManagementSystem.UseCases.Contracts.Interfaces.LeaveTypeInterfaces
{
	public interface IIsLeaveTypeNameExistsUseCase
	{
		Task<bool> ExecuteAsync(string name);
	}
}
