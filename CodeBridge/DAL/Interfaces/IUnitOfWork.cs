using CodeBridge.Models;

namespace CodeBridge.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Dog> Dogs { get; }

        Task<int> SaveChangesAsync();
    }
}
