using System.Linq.Expressions;

namespace MyTrainerHub.Core.Domain.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        T? GetById(Guid id);

        IEnumerable<T> GetAllWhere(Expression<Func<T, bool>> match);

        IEnumerable<T> GetAll();

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
