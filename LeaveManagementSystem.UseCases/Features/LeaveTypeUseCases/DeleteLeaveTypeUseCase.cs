using LeaveManagementSystem.UseCases.Contracts.Interfaces.LeaveTypeInterfaces;
using LeaveManagementSystem.UseCases.Contracts.Persistence;
namespace LeaveManagementSystem.UseCases.Features.LeaveTypeUseCases
{
	public class DeleteLeaveTypeUseCase : IDeleteLeaveTypeUseCase
	{
		private readonly ILeaveTypeRepository _leaveTypeRepository;

		public DeleteLeaveTypeUseCase(ILeaveTypeRepository leaveTypeRepository)
		{
			this._leaveTypeRepository = leaveTypeRepository;
		}
		public async Task<bool> ExecuteAsync(int id)
		{
			if (id <= 0)
				return false;

			var leaveType = await _leaveTypeRepository.GetByIdAsync(id);
			if (leaveType == null)
				return false;

			return await _leaveTypeRepository.DeleteAsync(leaveType);
		}
	}
}
