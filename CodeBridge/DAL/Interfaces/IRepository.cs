using Microsoft.EntityFrameworkCore;

namespace CodeBridge.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<bool> CreateAsync(T item);
        DbSet<T> GetAllRaw();
    }
}
