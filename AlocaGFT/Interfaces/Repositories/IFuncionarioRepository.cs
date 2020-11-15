using System.Collections.Generic;
using AlocaGFT.Interfaces.Generics;
using AlocaGFT.Models;

namespace AlocaGFT.Interfaces.Repositories
{
    public interface IFuncionarioRepository : ICrudRepository<Funcionario>
    {
        void AlocarEmVaga(Vaga vaga, Funcionario funcionario);
        void DesalocarEmVaga(Vaga vaga, Funcionario funcionario);
        List<Funcionario> GetTodosAtivosEmWA();
    }
}