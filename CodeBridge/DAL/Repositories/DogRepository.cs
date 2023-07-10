using CodeBridge.DAL.Interfaces;
using CodeBridge.DbContexts;
using CodeBridge.Entities;
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

        public async Task<IEnumerable<Dog>> GetAllAsync()
        {
            return await _context.Dogs.ToListAsync();
        }
    }
}
