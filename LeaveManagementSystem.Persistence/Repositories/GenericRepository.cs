using LeaveManagementSystem.Domain.Common;
using LeaveManagementSystem.Persistence.DatabaseContext;
using LeaveManagementSystem.UseCases.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Persistence.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		protected readonly HrLeaveManagementDbContext dbContext;

		public GenericRepository(HrLeaveManagementDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
		public async Task<int> CreateAsync(T entity)
		{
			await dbContext.AddAsync(entity);
			await dbContext.SaveChangesAsync();
			return entity.Id;
		}

		public async Task<bool> DeleteAsync(T entity)
		{
			dbContext.Remove(entity);
			await dbContext.SaveChangesAsync();
			return true;
		}

		public async Task<IReadOnlyList<T>> GetAsync()
		{
			return await dbContext.Set<T>().AsNoTracking().ToListAsync();
		}

		public async Task<T?> GetByIdAsync(int id)
		{
			return await dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<bool> IsExistsAsync(int id)
		{
			return await dbContext.Set<T>().AsNoTracking().AnyAsync(x => x.Id == id);
		}

		public async Task<bool> UpdateAsync(T entity)
		{
			dbContext.Update(entity);
			await dbContext.SaveChangesAsync();
			return true;
		}
	}
}
