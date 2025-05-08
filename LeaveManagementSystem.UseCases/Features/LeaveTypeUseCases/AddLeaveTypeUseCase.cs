using LeaveManagementSystem.Domain;
using LeaveManagementSystem.UseCases.Contracts.Interfaces.LeaveTypeInterfaces;
using LeaveManagementSystem.UseCases.Contracts.Persistence;

namespace LeaveManagementSystem.UseCases.Features.LeaveTypeUseCases
{
	public class AddLeaveTypeUseCase : IAddLeaveTypeUseCase
	{
		private readonly ILeaveTypeRepository _leaveTypeRepository;

		public AddLeaveTypeUseCase(ILeaveTypeRepository leaveTypeRepository)
		{
			this._leaveTypeRepository = leaveTypeRepository;
		}
		public async Task<int> Execute(LeaveType leaveType)
		{
			return await _leaveTypeRepository.CreateAsync(leaveType);
		}
	}
}
