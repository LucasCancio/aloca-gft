using System;
using AlocaGFT.Models;
using Microsoft.EntityFrameworkCore;

namespace AlocaGFT.Data.Seeds
{
    public static class FuncionarioSeed
    {
        public static void SeedFuncionario(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>().HasData(new Funcionario()
            {
                id = 1,
                nome = "Lucas Camargo",
                cargoid = 1,
                gftid = 1,
                inicio_wa = DateTime.Now,
                termino_wa = DateTime.Now.AddDays(15),
                matricula = "N412302",
                status = true
            });


            //Funcionario Tecnologia

            modelBuilder.Entity<Funcionario_Tecnologia>().HasData(new Funcionario_Tecnologia()
            {
                id = 1,
                funcionarioid = 1,
                tecnologiaid = 1,
            });

        }
    }
}