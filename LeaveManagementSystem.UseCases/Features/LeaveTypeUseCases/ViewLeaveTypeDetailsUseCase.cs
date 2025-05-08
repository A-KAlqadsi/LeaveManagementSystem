using LeaveManagementSystem.Domain;
using LeaveManagementSystem.UseCases.Contracts.Interfaces.LeaveTypeInterfaces;
using LeaveManagementSystem.UseCases.Contracts.Persistence;

namespace LeaveManagementSystem.UseCases.Features.LeaveTypeUseCases
{
	public class ViewLeaveTypeDetailsUseCase : IViewLeaveTypeDetailsUseCase
	{
		private readonly ILeaveTypeRepository _leaveTypeRepository;

		public ViewLeaveTypeDetailsUseCase(ILeaveTypeRepository leaveTypeRepository)
		{
			this._leaveTypeRepository = leaveTypeRepository;
		}
		public async Task<LeaveType?> ExecuteAsync(int id)
		{
			return await _leaveTypeRepository.GetByIdAsync(id);
		}
	}
}
