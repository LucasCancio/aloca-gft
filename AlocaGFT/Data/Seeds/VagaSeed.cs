using System;
using AlocaGFT.Models;
using Microsoft.EntityFrameworkCore;

namespace AlocaGFT.Data.Seeds
{
    public static class VagaSeed
    {
        public static void SeedVaga(this ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Vaga>().HasData(new Vaga()
            {
                id = 1,
                projeto="Itau",
                abertura= DateTime.Now,
                codigoVaga= $"#ITAU-{DateTime.Now.Year}-{DateTime.Now.Month}",
                qtdVaga=2,
                descricao="Desenvolvedor Java Senior",
                homeOffice= true,            
                status=true
            });

            modelBuilder.Entity<Vaga>().HasData(new Vaga()
            {
                id = 2,
                projeto="Santander",
                abertura= DateTime.Now.AddYears(1),
                codigoVaga= $"#SANTANDER-{DateTime.Now.AddYears(1).Year}-{DateTime.Now.AddYears(1).Month}",
                qtdVaga=1,
                descricao="Desenvolvedor IOS",
                homeOffice= false,            
                status=true
            });

            //Vaga Tecnologia

            modelBuilder.Entity<Vaga_Tecnologia>().HasData(new Vaga_Tecnologia()
            {
                id = 1,
                vagaid=1,
                tecnologiaid = 2,
            });

            modelBuilder.Entity<Vaga_Tecnologia>().HasData(new Vaga_Tecnologia()
            {
                id = 2,
                vagaid=2,
                tecnologiaid = 3,
            });
        }
    }
}