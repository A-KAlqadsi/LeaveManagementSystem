using LeaveManagementSystem.Domain;
using LeaveManagementSystem.Persistence.DatabaseContext;
using LeaveManagementSystem.UseCases.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Persistence.Repositories
{
	public class LeaveTypesRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
	{
		public LeaveTypesRepository(HrLeaveManagementDbContext dbContext) : base(dbContext)
		{

		}

		public async Task<bool> IsLeaveTypeNameExists(string name)
		{
			return await dbContext.LeaveTypes.AsNoTracking().AnyAsync(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
		}
	}
}
