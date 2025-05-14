using LeaveManagementSystem.Persistence.DatabaseContext;
using LeaveManagementSystem.Persistence.Repositories;
using LeaveManagementSystem.UseCases.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LeaveManagementSystem.Persistence
{
	public static class PersistenceServiceRegistration
	{
		public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
		{

			services.AddDbContext<HrLeaveManagementDbContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
			});

			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			services.AddScoped<ILeaveTypeRepository, LeaveTypesRepository>();

			return services;
		}
	}
}
