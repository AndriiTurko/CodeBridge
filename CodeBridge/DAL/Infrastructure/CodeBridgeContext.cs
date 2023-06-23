using CodeBridge.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeBridge.DAL.Infrastructure
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
            modelBuilder.ApplyConfiguration(new DogConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
