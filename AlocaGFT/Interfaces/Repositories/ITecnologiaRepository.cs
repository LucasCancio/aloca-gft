using System.Collections.Generic;
using AlocaGFT.Interfaces.Generics;
using AlocaGFT.Models;
using AlocaGFT.Utils;
using Microsoft.AspNetCore.Http;

namespace AlocaGFT.Interfaces.Repositories
{
    public interface ITecnologiaRepository : ICrudRepository<Tecnologia>
    {
        void SalvarTecnologiasDoFuncionario(Funcionario funcionario, List<long> tecnologiasIds);
        List<Tecnologia> GetTecnologiasPorFuncionario(Funcionario funcionario);

        void SalvarTecnologiasDaVaga(Vaga vaga, List<long> tecnologiasIds);
        List<Tecnologia> GetTecnologiasPorVaga(Vaga vaga);
        void UploadTecnologia(IFormFile image, Tecnologia tecnologia);
    }
}