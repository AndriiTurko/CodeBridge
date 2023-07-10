using CodeBridge.DAL.Infrastructure;
using CodeBridge.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeBridge.DbContexts
{
    public class CodeBridgeContext : DbContext
    {
        public const string Default_Schema = "dbo";

        public DbSet<Dog> Dogs { get; set; }

        public CodeBridgeContext()
        {
        }

        public CodeBridgeContext(DbContextOptions<CodeBridgeContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>()
                .HasData(
                    new Dog("Neo")
                    {
                        Id = Guid.NewGuid(),
                        Color = "red & amber",
                        TailLength = 22,
                        Weight = 32
                    },
                    new Dog("Jessy")
                    {
                        Id = Guid.NewGuid(),
                        Color = "black & white",
                        TailLength = 7,
                        Weight = 14
                    }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
