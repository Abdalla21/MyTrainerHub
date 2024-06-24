using MyTrainerHub.Core.Domain.IUnitOfWork;
using MyTrainerHub.Infrastructure.DatabaseContext;

namespace MyTrainerHub.Infrastructure.UnitOfWork
{
    public class UnitOfWork(ApplicationDBContext applicationDbContext) : IUnitOfWork
    {
        //tableName = new GenericRepository<tableName>(_context);

        //public IGenericRepository<> tableName { get; private set; }


        public int Complete()
        {
            return applicationDbContext.SaveChanges();
        }

        public void Dispose()
        {
            applicationDbContext.Dispose();
        }
    }
}
