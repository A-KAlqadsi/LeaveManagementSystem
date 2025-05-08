using LeaveManagementSystem.UseCases.Contracts.Interfaces.LeaveTypeInterfaces;
using LeaveManagementSystem.UseCases.Contracts.Persistence;

namespace LeaveManagementSystem.UseCases.Features.LeaveTypeUseCases
{
	public class IsLeaveTypeExistUseCase : IIsLeaveTypeExistUseCase
	{
		private readonly ILeaveTypeRepository leaveTypeRepository;

		public IsLeaveTypeExistUseCase(ILeaveTypeRepository leaveTypeRepository)
		{
			this.leaveTypeRepository = leaveTypeRepository;
		}
		public async Task<bool> ExecuteAsync(int id)
		{
			return await leaveTypeRepository.IsExistsAsync(id);
		}
	}
}
