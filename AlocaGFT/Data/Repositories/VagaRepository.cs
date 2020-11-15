using System;
using System.Collections.Generic;
using System.Linq;
using AlocaGFT.Data.Repositories.Generics;
using AlocaGFT.Interfaces.Repositories;
using AlocaGFT.Models;
using Microsoft.EntityFrameworkCore;

namespace AlocaGFT.Data.Repositories
{
    public class VagaRepository : CrudRepository<Vaga>, IVagaRepository
    {
        public VagaRepository(AlocaGFTDbContext context) : base(context)
        {}

        public List<Vaga> GetPorTecnologia(Tecnologia tecnologia)
        {
            if (tecnologia == null) throw new NullReferenceException("Tecnologia inválida!");

            List<Vaga> vagas = _context.Vagas_Tecnologias
                                       .Where(v => v.tecnologia == tecnologia)
                                       .Select(v => v.vaga)
                                       .ToList();
            return vagas;
        }

        public List<Vaga> GetTodosAtivosApenasComVagas()
        {
            List<Vaga> vagas = _context.Vagas
                                            .Where(f => f.status.Value && f.qtdVaga > 0)
                                            .ToList();

            return vagas;
        }
    }
}