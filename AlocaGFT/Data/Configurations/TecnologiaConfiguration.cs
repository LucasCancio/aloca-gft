using AlocaGFT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlocaGFT.Data.Configurations
{
    public class TecnologiaConfiguration : IEntityTypeConfiguration<Tecnologia>
    {
        public void Configure(EntityTypeBuilder<Tecnologia> builder)
        {
            builder.HasKey(t => t.id);
            builder.Property(t => t.status)
                    .IsRequired()
                    .HasDefaultValue(true);
        }
    }
}