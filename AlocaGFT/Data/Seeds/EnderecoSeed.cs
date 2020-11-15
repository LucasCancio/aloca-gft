using AlocaGFT.Models;
using Microsoft.EntityFrameworkCore;

namespace AlocaGFT.Data.Seeds
{
    public static class EnderecoSeed
    {
        public static void SeedEndereco(this ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Endereco>().HasData(new Endereco()
            {
                id=1,
                cep="06454-000",
                numero=585,
                bairro="Alphaville Industrial",
                logradouro="Alameda Rio Negro",
                cidade="Barueri",
                uf="SP",
                latitude=-23.5004973f,
                longitude=-46.8508644f,
                status=true
            });

            modelBuilder.Entity<Endereco>().HasData(new Endereco()
            {
                id=2,
                cep="18095-450",
                numero=98,
                bairro="Jardim Santa Rosália",
                logradouro="Av. São Francisco",
                cidade="Sorocaba",
                uf="SP",
                latitude=-23.4871076f,
                longitude=-47.4448119f,
                status=true
            });
        }
    }
}