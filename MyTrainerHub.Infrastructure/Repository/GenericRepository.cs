using Microsoft.EntityFrameworkCore;
using MyTrainerHub.Core.Domain.Repository;
using MyTrainerHub.Infrastructure.DatabaseContext;
using System.Linq.Expressions;

namespace MyTrainerHub.Infrastructure.Repository
{
    public class GenericRepository<T>(ApplicationDBContext context) : IGenericRepository<T>
        where T : class
    {

        private readonly DbSet<T> _dbSet = context.Set<T>();

        public void Add(T entity) => _dbSet.Add(entity);

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll() => [.. _dbSet];

        public IEnumerable<T> GetAllWhere(Expression<Func<T, bool>> match) => [.. _dbSet.Where(match)];

        public T? GetById(Guid id) => _dbSet.Find(id);

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
