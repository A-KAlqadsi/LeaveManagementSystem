using LeaveManagementSystem.Domain;
using LeaveManagementSystem.Persistence.DatabaseContext;
using LeaveManagementSystem.UseCases.Contracts.Persistence;

namespace LeaveManagementSystem.Persistence.Repositories
{
	public class LeaveTypesRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
	{
		public LeaveTypesRepository(HrLeaveManagementDbContext dbContext) : base(dbContext)
		{

		}

	}
}
