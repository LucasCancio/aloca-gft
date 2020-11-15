using System.Collections.Generic;
using System.Linq;
using AlocaGFT.Data.Repositories.Generics;
using AlocaGFT.Interfaces.Repositories;
using AlocaGFT.Models;
using AlocaGFT.Utils.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AlocaGFT.Data.Repositories
{
    public class GftRepository : CrudRepository<Gft>, IGftRepository
    {
        public GftRepository(AlocaGFTDbContext context) : base(context)
        { }

        public override Gft GetPorId(long id)
        {
            Gft gft = _context.Gfts
                                .Where(g => g.id == id)
                                .Include(g => g.endereco)
                                .FirstOrDefault();

            if (gft == null) throw new EntidadeNaoEncontradaException($"Gft não encontrada!");
            return gft;
        }

        public override List<Gft> GetTodosAtivos()
        {
            List<Gft> gfts = _context.Gfts
                                .Include(g => g.endereco)
                                .Where(g => g.status.Value)
                                .ToList();
            return gfts;
        }
    }
}