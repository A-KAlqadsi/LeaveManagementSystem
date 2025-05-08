using LeaveManagementSystem.Domain;
using LeaveManagementSystem.UseCases.Contracts.Interfaces.LeaveTypeInterfaces;
using LeaveManagementSystem.UseCases.Contracts.Persistence;

namespace LeaveManagementSystem.UseCases.Features.LeaveTypeUseCases
{
	public class ViewLeaveTypesUseCase : IViewLeaveTypesUseCase
	{
		private readonly ILeaveTypeRepository _leaveTypeRepository;

		public ViewLeaveTypesUseCase(ILeaveTypeRepository leaveTypeRepository)
		{
			this._leaveTypeRepository = leaveTypeRepository;
		}

		public async Task<IReadOnlyList<LeaveType>> ExecuteAsync()
		{
			return await _leaveTypeRepository.GetAsync();
		}
	}
}
