using Microsoft.EntityFrameworkCore;

namespace CodeBridge.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<bool> CreateAsync(T item);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
