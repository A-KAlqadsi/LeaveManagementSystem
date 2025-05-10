using LeaveManagementSystem.Domain;

namespace LeaveManagementSystem.UseCases.Contracts.Persistence
{
	public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
	{
		Task<bool> IsLeaveTypeNameExists(string name);

	}
}
