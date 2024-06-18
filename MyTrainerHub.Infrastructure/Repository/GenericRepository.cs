using Microsoft.EntityFrameworkCore;
using MyTrainerHub.Core.Domain.IGenericRepository;
using MyTrainerHub.Infrastructure.DatabaseContext;
using System.Linq.Expressions;

namespace MyTrainerHub.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly DbSet<T> _dbSet;
        private readonly ApplicationDBContext _dbContext;

        public GenericRepository(ApplicationDBContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<T>();
        }

        public void Add(T entity) => _dbSet.Add(entity);

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll() => [.. _dbSet];

        public IEnumerable<T> GetAllWhere(Expression<Func<T, bool>> Match) => [.. _dbSet.Where(Match)];

        public T? GetById(Guid id) => _dbSet.Find(id);

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
