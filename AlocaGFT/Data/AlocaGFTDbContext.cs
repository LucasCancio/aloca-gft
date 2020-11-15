using System;
using System.Collections.Generic;
using System.Text;
using AlocaGFT.Data.Configurations;
using AlocaGFT.Data.Seeds;
using AlocaGFT.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlocaGFT.Data
{
    public class AlocaGFTDbContext : IdentityDbContext
    {
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Funcionario_Tecnologia> Funcionarios_Tecnologias { get; set; }
        public DbSet<Gft> Gfts { get; set; }
        public DbSet<Tecnologia> Tecnologias { get; set; }
        public DbSet<Vaga> Vagas { get; set; }
        public DbSet<Vaga_Tecnologia> Vagas_Tecnologias { get; set; }
        public DbSet<Alocacao> Alocacoes { get; set; }

        public AlocaGFTDbContext(DbContextOptions<AlocaGFTDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new FuncionarioConfiguration());
            modelBuilder.ApplyConfiguration(new GftConfiguration());
            modelBuilder.ApplyConfiguration(new TecnologiaConfiguration());
            modelBuilder.ApplyConfiguration(new VagaConfiguration());

            modelBuilder.SeedEndereco();
            modelBuilder.SeedGft();

            modelBuilder.SeedCargo();
            modelBuilder.SeedTecnologia();

            modelBuilder.SeedVaga();
            modelBuilder.SeedFuncionario();
        }
    }
}
