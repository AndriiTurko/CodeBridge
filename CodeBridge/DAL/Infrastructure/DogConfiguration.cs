using CodeBridge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeBridge.DAL.Infrastructure
{
    public class DogConfiguration : IEntityTypeConfiguration<Dog>
    {
        public void Configure(EntityTypeBuilder<Dog> builder)
        {
            builder.ToTable("Dogs", CodeBridgeContext.Default_Schema);

            builder.Property(data => data.Name);
            builder.Property(data => data.Color);
            builder.Property(data => data.Tail_length);
            builder.Property(data => data.Weight);
        }
    }
}
