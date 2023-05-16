namespace ContribuyentesDGII.Api.Services
{
    public interface IGenericService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        Task<T> Create(T entity);
        Task<T?> Update(int id, T entity);
        Task<bool> Delete(int id);
    }
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _repository.GetAll();
        }
        public async Task<T> GetById(int id)
        {
            return await _repository.GetById(id);
        }
        public async Task<T> Create(T entity)
        {
            return await _repository.Create(entity);
        }
        public async Task<T?> Update(int id, T entity)
        {
            return await _repository.Update(id, entity);
        }
        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _repository.FindByCondition(expression);
        }
    }
}
