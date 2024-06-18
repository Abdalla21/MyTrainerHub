using System.Linq.Expressions;

namespace MyTrainerHub.Core.Domain.IGenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        T? GetById(Guid id);

        IEnumerable<T> GetAllWhere(Expression<Func<T, bool>> Match);

        IEnumerable<T> GetAll();

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
