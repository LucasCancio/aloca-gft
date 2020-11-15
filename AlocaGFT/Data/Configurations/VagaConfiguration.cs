using AlocaGFT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlocaGFT.Data.Configurations
{
    public class VagaConfiguration : IEntityTypeConfiguration<Vaga>
    {
        public void Configure(EntityTypeBuilder<Vaga> builder)
        {
            builder.HasKey(v => v.id);
            builder.Property(v => v.status)
                   .IsRequired()
                   .HasDefaultValue(true);
        }
    }
}