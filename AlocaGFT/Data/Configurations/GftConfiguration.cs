using AlocaGFT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlocaGFT.Data.Configurations
{
    public class GftConfiguration : IEntityTypeConfiguration<Gft>
    {
        public void Configure(EntityTypeBuilder<Gft> builder)
        {
            builder.HasKey(g => g.id);
            builder.Property(g => g.status)
                   .IsRequired()
                   .HasDefaultValue(true);
        }
    }
}