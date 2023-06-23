using CodeBridge.DAL.Infrastructure;
using CodeBridge.DAL.Interfaces;
using CodeBridge.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeBridge.DAL.Repositories
{
    public class DogRepository : IRepository<Dog>
    {
        private readonly CodeBridgeContext _context;

        public DogRepository(CodeBridgeContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Dog dog)
        {
            var createdItem = await _context.Dogs.AddAsync(dog);

            return createdItem != null;
        }

        public DbSet<Dog> GetAllRaw()
        {
            return _context.Dogs;
        }
    }
}
