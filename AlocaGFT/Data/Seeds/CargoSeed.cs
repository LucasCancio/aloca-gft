using AlocaGFT.Models;
using AlocaGFT.Utils.Enums;
using Microsoft.EntityFrameworkCore;

namespace AlocaGFT.Data.Seeds
{
    public static class CargoSeed
    {
        public static void SeedCargo(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargo>().HasData(new Cargo()
            {
                id = 1,
                nome = "Starter",
                level = CargoLevels.L0,
                status = true
            });
        }
    }
}