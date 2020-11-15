using System.Collections.Generic;
using AlocaGFT.Interfaces.Generics;
using AlocaGFT.Models;

namespace AlocaGFT.Interfaces.Repositories
{
    public interface IVagaRepository : ICrudRepository<Vaga>
    {
        List<Vaga> GetPorTecnologia(Tecnologia tecnologia);
        List<Vaga> GetTodosAtivosApenasComVagas();
    }
}