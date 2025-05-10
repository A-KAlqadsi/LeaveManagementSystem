using LeaveManagementSystem.UseCases.Contracts.Interfaces.LeaveTypeInterfaces;
using LeaveManagementSystem.UseCases.Contracts.Persistence;

namespace LeaveManagementSystem.UseCases.Features.LeaveTypeUseCases
{
	public class IsLeaveTypeNameExistsUseCase : IIsLeaveTypeNameExistsUseCase
	{
		private readonly ILeaveTypeRepository leaveTypeRepository;

		public IsLeaveTypeNameExistsUseCase(ILeaveTypeRepository leaveTypeRepository)
		{
			this.leaveTypeRepository = leaveTypeRepository;
		}

		public async Task<bool> ExecuteAsync(string name)
		{
			return await leaveTypeRepository.IsLeaveTypeNameExists(name);
		}
	}
}
