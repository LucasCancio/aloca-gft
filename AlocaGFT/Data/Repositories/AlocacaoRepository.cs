using System;
using System.Collections.Generic;
using System.Linq;
using AlocaGFT.Interfaces.Repositories;
using AlocaGFT.Models;
using Microsoft.EntityFrameworkCore;

namespace AlocaGFT.Data.Repositories
{
    public class AlocacaoRepository : IAlocacaoRepository
    {
        private readonly AlocaGFTDbContext _context;
        public AlocacaoRepository(AlocaGFTDbContext context)
        {
            this._context = context;
        }
        public List<Funcionario> GetFuncionariosNaVaga(Vaga vaga)
        {
            var funcionarios = _context.Funcionarios
                                                .Include(f => f.gft)
                                                .Include(f => f.cargo)
                                                .Where(f => f.vagaid == vaga.id)
                                                .ToList();

            return funcionarios;
        }

        public List<Alocacao> GetTodosAtivos()
        {
            return _context.Alocacoes
                                .Include(al => al.funcionario)
                                .Include(al => al.vaga)
                                .Where(al => al.funcionario.status.Value && al.vaga.status.Value)
                                .ToList();
        }

        public Alocacao Salvar(Alocacao alocacao)
        {
            if (alocacao == null) throw new NullReferenceException($"Alocação inválida!");

            var state = alocacao.HasId ? EntityState.Modified : EntityState.Added;

            _context.Entry(alocacao).State = state;
            _context.SaveChanges();
            return alocacao;
        }
    }
}