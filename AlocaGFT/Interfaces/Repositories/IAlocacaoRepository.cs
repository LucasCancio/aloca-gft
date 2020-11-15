using System.Collections.Generic;
using AlocaGFT.Models;

namespace AlocaGFT.Interfaces.Repositories
{
    public interface IAlocacaoRepository
    {
        List<Alocacao> GetTodosAtivos();
        Alocacao Salvar(Alocacao alocacao);//Update e Insert
        List<Funcionario> GetFuncionariosNaVaga(Vaga vaga);
    }
}