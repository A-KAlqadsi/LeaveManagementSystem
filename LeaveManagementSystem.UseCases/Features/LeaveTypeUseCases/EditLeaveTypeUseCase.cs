using LeaveManagementSystem.Domain;
using LeaveManagementSystem.UseCases.Contracts.Interfaces.LeaveTypeInterfaces;
using LeaveManagementSystem.UseCases.Contracts.Persistence;

namespace LeaveManagementSystem.UseCases.Features.LeaveTypeUseCases
{
	public class EditLeaveTypeUseCase : IEditLeaveTypeUseCase
	{
		private readonly ILeaveTypeRepository _leaveTypeRepository;

		public EditLeaveTypeUseCase(ILeaveTypeRepository leaveTypeRepository)
		{
			this._leaveTypeRepository = leaveTypeRepository;
		}
		public async Task<bool> ExecuteAsync(int id, LeaveType leaveType)
		{
			if (id != leaveType.Id)
				return false;

			var existLeaveType = await _leaveTypeRepository.GetByIdAsync(id);

			if (existLeaveType == null)
				return false;

			return await _leaveTypeRepository.UpdateAsync(leaveType);

		}
	}
}
