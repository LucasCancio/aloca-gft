using AlocaGFT.Models;
using Microsoft.EntityFrameworkCore;

namespace AlocaGFT.Data.Seeds
{
    public static class GftSeed
    {
        public static void SeedGft(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gft>().HasData(new Gft()
            {
                id=1,
                nome= "GFT Alphaville",
                enderecoid=1,
                telefone="(11)2176-3253", 
                status=true
            });
            modelBuilder.Entity<Gft>().HasData(new Gft()
            {
                id=2,
                nome= "GFT Sorocaba",
                enderecoid=2,
                telefone="(11)2176-3253", 
                status=true
            });
        }
    }
}