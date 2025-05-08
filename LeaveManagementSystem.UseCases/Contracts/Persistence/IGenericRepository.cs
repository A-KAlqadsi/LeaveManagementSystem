namespace LeaveManagementSystem.UseCases.Contracts.Persistence
{
	public interface IGenericRepository<T> where T : class
	{
		Task<IReadOnlyList<T>> GetAsync();
		Task<T?> GetByIdAsync(int id);
		Task<int> CreateAsync(T entity);
		Task<bool> UpdateAsync(T entity);
		Task<bool> DeleteAsync(T entity);
	}
}
