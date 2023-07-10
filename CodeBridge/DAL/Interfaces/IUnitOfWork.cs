using CodeBridge.Entities;

namespace CodeBridge.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Dog> Dogs { get; }

        Task<bool> SaveChangesAsync();
    }
}
