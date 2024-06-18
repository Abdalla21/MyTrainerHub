using MyTrainerHub.Core.Domain.IUnitOfWork;
using MyTrainerHub.Infrastructure.DatabaseContext;

namespace MyTrainerHub.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDBContext _context;

        public UnitOfWork(ApplicationDBContext applicationDBContext)
        {
            _context = applicationDBContext;
            //tableName = new GenericRepository<tableName>(_context);
        }

        //public IGenericRepository<> tableName { get; private set; }


        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
