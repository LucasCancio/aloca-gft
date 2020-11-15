using AlocaGFT.Data.Repositories.Generics;
using AlocaGFT.Interfaces.Repositories;
using AlocaGFT.Models;

namespace AlocaGFT.Data.Repositories
{
    public class EnderecoRepository : CrudRepository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(AlocaGFTDbContext context) : base(context)
        {
        }
    }
}