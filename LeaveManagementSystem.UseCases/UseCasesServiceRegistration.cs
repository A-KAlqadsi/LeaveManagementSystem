using LeaveManagementSystem.UseCases.Contracts.Interfaces.LeaveTypeInterfaces;
using LeaveManagementSystem.UseCases.Features.LeaveTypeUseCases;
using Microsoft.Extensions.DependencyInjection;

namespace LeaveManagementSystem.UseCases
{
	public static class UseCasesServiceRegistration
	{
		public static IServiceCollection AddUseCaseServices(this IServiceCollection services)
		{
			// Leave Type Use Cases
			services.AddTransient<IViewLeaveTypesUseCase, ViewLeaveTypesUseCase>();
			services.AddTransient<IViewLeaveTypeDetailsUseCase, ViewLeaveTypeDetailsUseCase>();
			services.AddTransient<IAddLeaveTypeUseCase, AddLeaveTypeUseCase>();
			services.AddTransient<IEditLeaveTypeUseCase, EditLeaveTypeUseCase>();
			services.AddTransient<IDeleteLeaveTypeUseCase, DeleteLeaveTypeUseCase>();
			services.AddTransient<IIsLeaveTypeExistUseCase, IsLeaveTypeExistUseCase>();
			return services;
		}
	}
}
