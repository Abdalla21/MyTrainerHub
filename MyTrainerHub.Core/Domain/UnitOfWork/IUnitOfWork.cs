namespace MyTrainerHub.Core.Domain.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {


        public int Complete();
    }
}
