using System;
using System.Collections.Generic;
using System.Linq;
using AlocaGFT.Data.Repositories.Generics;
using AlocaGFT.Interfaces.Repositories;
using AlocaGFT.Models;
using AlocaGFT.Utils.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AlocaGFT.Data.Repositories
{
    public class FuncionarioRepository : CrudRepository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(AlocaGFTDbContext context) : base(context)
        { }
        public const int DIAS_EM_WA = 15;

        public override Funcionario GetPorId(long id)
        {
            Funcionario funcionario = _context.Funcionarios
                                                    .Where(f => f.id == id)
                                                    .Include(f => f.cargo)
                                                    .Include(f => f.gft)
                                                    .Include(f => f.vaga)
                                                    .FirstOrDefault();

            if (funcionario == null) throw new EntidadeNaoEncontradaException($"Funcionário não encontrado!");
            return funcionario;
        }

        public override List<Funcionario> GetTodosAtivos()
        {
            List<Funcionario> funcionarios = _context.Funcionarios
                                                    .Include(f => f.cargo)
                                                    .Include(f => f.gft)
                                                    .Include(f => f.vaga)
                                                    .Where(f => f.status.Value)
                                                    .ToList();

            return funcionarios;
        }

        public List<Funcionario> GetTodosAtivosEmWA()
        {
            List<Funcionario> funcionarios = _context.Funcionarios
                                                   .Include(f => f.cargo)
                                                   .Include(f => f.gft)
                                                   .Include(f => f.vaga)
                                                   .Where(f => f.status.Value && f.vagaid == null)
                                                   .ToList();

            return funcionarios;
        }

        public void AlocarEmVaga(Vaga vaga, Funcionario funcionario)
        {
            funcionario.vaga = vaga;
            funcionario.termino_wa = DateTime.Now;

            _context.Entry(funcionario).State = EntityState.Modified;

            vaga.qtdVaga--;
            _context.Entry(vaga).State = EntityState.Modified;

            _context.SaveChanges();
        }

        public void DesalocarEmVaga(Vaga vaga, Funcionario funcionario)
        {
            funcionario.vaga = null;
            funcionario.inicio_wa = DateTime.Now;
            funcionario.termino_wa = DateTime.Now.AddDays(DIAS_EM_WA);

            _context.Entry(funcionario).State = EntityState.Modified;

            vaga.qtdVaga++;
            _context.Entry(vaga).State = EntityState.Modified;

            _context.SaveChanges();
        }

    }
}