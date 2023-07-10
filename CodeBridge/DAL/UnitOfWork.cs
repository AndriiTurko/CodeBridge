using CodeBridge.DAL.Interfaces;
using CodeBridge.DAL.Repositories;
using CodeBridge.DbContexts;
using CodeBridge.Entities;

namespace CodeBridge.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CodeBridgeContext _context;

        bool disposed;

        private DogRepository? _dogRepository;

        public UnitOfWork(CodeBridgeContext context)
        {
            _context = context;
            disposed = false;
        }

        public IRepository<Dog> Dogs
        {
            get
            {
                _dogRepository ??= new DogRepository(_context);

                return _dogRepository;
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    _context.Dispose();

                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) >= 0;
        }
    }
}
