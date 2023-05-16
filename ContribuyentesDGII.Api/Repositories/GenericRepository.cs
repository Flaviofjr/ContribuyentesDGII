
namespace ContribuyentesDGII.Api.Repositories
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        Task<T> Create(T entity);
        Task<T?> Update(int id, T entity);
        Task<bool> Delete(int id);
    }
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ContribuyentesDbContext _contribuyentesDbContext;
        public GenericRepository(ContribuyentesDbContext contribuyentesDbContext)
        {
            _contribuyentesDbContext = contribuyentesDbContext;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _contribuyentesDbContext.Set<T>().ToListAsync();
        }
        public async Task<T> GetById(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _contribuyentesDbContext.Set<T>().FindAsync(id);
#pragma warning restore CS8603 // Possible null reference return.
        }
        public async Task<T> Create(T entity)
        {
            _contribuyentesDbContext.Set<T>().Add(entity);
            _contribuyentesDbContext.SaveChanges();
            return entity;
        }
        public async Task<T?> Update(int id, T entity)
        {
            //_contribuyentesDbContext.Set<T>().Update(entity);
            var existingEntity = await _contribuyentesDbContext.Set<T>().FindAsync(id);
            if (existingEntity == null)
            {
                return null;
            }

            _contribuyentesDbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
            _contribuyentesDbContext.SaveChanges();
            return existingEntity;
        }
        public async Task<bool> Delete(int id)
        {
            var entity = await _contribuyentesDbContext.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            _contribuyentesDbContext.Set<T>().Remove(entity);
            await _contribuyentesDbContext.SaveChangesAsync();
            return true;
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _contribuyentesDbContext.Set<T>().Where(expression).AsNoTracking();
        }

    }
}
