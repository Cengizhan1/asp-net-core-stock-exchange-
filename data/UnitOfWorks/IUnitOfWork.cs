using Core.Entities;
using Data.Repositories.Abstraction;

namespace Data.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IRepository<T> GetRepository<T>() where T : class , IBaseEntity , new();

        Task<int> SaveAsync();

        int Save();
    }
}
