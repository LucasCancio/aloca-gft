using AlocaGFT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlocaGFT.Data.Configurations
{
    public class FuncionarioConfiguration : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(f => f.id);
            builder.Property(f => f.status)
                    .IsRequired()
                    .HasDefaultValue(true);
        }
    }
}