using LeaveManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Persistence.DatabaseContext
{
	public class HrLeaveManagementDbContext : DbContext
	{
		public HrLeaveManagementDbContext(DbContextOptions<HrLeaveManagementDbContext> options) : base(options)
		{

		}
		public DbSet<LeaveType> LeaveTypes { get; set; }
	}
}
