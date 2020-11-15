using AlocaGFT.Models;
using Microsoft.EntityFrameworkCore;

namespace AlocaGFT.Data.Seeds
{
    public static class TecnologiaSeed
    {
        public static void SeedTecnologia(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tecnologia>().HasData(new Tecnologia()
            {
                id = 1,
                nome = "DotNet",
                imageName = "dotnet-icon.png",
                status = true
            });

            modelBuilder.Entity<Tecnologia>().HasData(new Tecnologia()
            {
                id = 2,
                nome = "Java",
                imageName = "java-icon.png",
                status = true
            });

            modelBuilder.Entity<Tecnologia>().HasData(new Tecnologia()
            {
                id = 3,
                nome = "Swift",
                imageName = "swift-icon.png",
                status = true
            });
        }
    }
}