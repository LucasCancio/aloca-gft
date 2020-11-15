using System;
using System.Collections.Generic;
using System.Linq;
using AlocaGFT.Data.Repositories.Generics;
using AlocaGFT.Interfaces.Repositories;
using AlocaGFT.Models;
using AlocaGFT.Utils;
using AlocaGFT.Utils.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AlocaGFT.Data.Repositories
{
    public class TecnologiaRepository : CrudRepository<Tecnologia>, ITecnologiaRepository //Refatorar -> Colocar upload em TecnologiaService
    {
        private readonly ImageUpload _upload;
        public TecnologiaRepository(AlocaGFTDbContext context, ImageUpload upload) : base(context)
        {
            this._upload = upload;
        }

        public override Tecnologia GetPorId(long id)
        {
            Tecnologia tecnologia = _context.Tecnologias.Find(id);
            if (tecnologia == null) throw new EntidadeNaoEncontradaException($"Tecnologia não encontrada!");

            tecnologia.imageSource = _upload.GetUploadedFilePath(tecnologia.id, tecnologia.imageName);

            return tecnologia;
        }

        public void UploadTecnologia(IFormFile image, Tecnologia tecnologia)
        {
            _upload.UploadFile(image, tecnologia.id);
        }
        public override List<Tecnologia> GetTodosAtivos()
        {
            List<Tecnologia> tecnologias = _context.Tecnologias.ToList();
            tecnologias.Where(tecnologia => tecnologia.status.Value).ToList();

            tecnologias.ForEach(tecnologia =>
            {
                tecnologia.imageSource = _upload.GetUploadedFilePath(tecnologia.id, tecnologia.imageName);
            });

            return tecnologias;
        }

        public List<Tecnologia> GetTecnologiasPorFuncionario(Funcionario funcionario)
        {
            var tecnologias = _context.Funcionarios_Tecnologias
                                        .Where(ft => ft.funcionario.id == funcionario.id)
                                        .Select(ft => ft.tecnologia)
                                        .ToList();
            tecnologias.ForEach(tecnologia =>
            {
                tecnologia.imageSource = _upload.GetUploadedFilePath(tecnologia.id, tecnologia.imageName);
            });

            return tecnologias;
        }

        public List<Tecnologia> GetTecnologiasPorVaga(Vaga vaga)
        {
            var tecnologias = _context.Vagas_Tecnologias
                                        .Where(vt => vt.vaga.id == vaga.id)
                                        .Select(vt => vt.tecnologia)
                                        .ToList();
            tecnologias.ForEach(tecnologia =>
            {
                tecnologia.imageSource = _upload.GetUploadedFilePath(tecnologia.id, tecnologia.imageName);
            });

            return tecnologias;
        }

        public void SalvarTecnologiasDoFuncionario(Funcionario funcionario, List<long> tecnologiasIds)
        {
            if (funcionario == null) throw new NullReferenceException($"Funcionário inválido!");
            List<Tecnologia> tecnologias = new List<Tecnologia>();
            if (tecnologiasIds != null)
            {
                tecnologias = _context.Tecnologias
                                              .Where(tec => tecnologiasIds.Contains(tec.id))
                                              .ToList();
            }
            var state = funcionario.HasId ? EntityState.Modified : EntityState.Added;

            if (state == EntityState.Added)
            {
                foreach (Tecnologia tecnologia in tecnologias)
                {
                    _context.Funcionarios_Tecnologias.Add(new Funcionario_Tecnologia()
                    {
                        funcionario = funcionario,
                        tecnologia = tecnologia
                    });
                }
            }
            else
            {
                ModificarTecnologiasFuncionarios(funcionario, tecnologias);
            }

            _context.SaveChanges();
        }

        private void ModificarTecnologiasFuncionarios(Funcionario funcionario, List<Tecnologia> tecnologias)
        {
            var tecnologiasDoFuncionarioNoBanco = _context.Funcionarios_Tecnologias
                                                                           .Where(ft => ft.funcionario.id == funcionario.id)
                                                                           .Select(ft => ft.tecnologia)
                                                                           .ToList();

            var tecnologiasPraExcluir = tecnologiasDoFuncionarioNoBanco
                                                    .Where(t => !tecnologias.Contains(t))
                                                    .ToList();
            var tecnologiasPraInserir = tecnologias
                                                .Where(t => !tecnologiasDoFuncionarioNoBanco.Contains(t))
                                                .ToList();

            tecnologiasPraExcluir.ForEach(tec =>
            {
                var tecnologiaFuncionario = _context.Funcionarios_Tecnologias
                                                                    .Where(ft => ft.tecnologia.id == tec.id && ft.funcionario.id == funcionario.id)
                                                                    .FirstOrDefault();

                _context.Funcionarios_Tecnologias.Remove(tecnologiaFuncionario);
            });

            tecnologiasPraInserir.ForEach(tec =>
            {
                _context.Funcionarios_Tecnologias.Add(new Funcionario_Tecnologia()
                {
                    funcionario = funcionario,
                    tecnologia = tec
                });
            });
        }


        public void SalvarTecnologiasDaVaga(Vaga vaga, List<long> tecnologiasIds)
        {
            if (vaga == null) throw new NullReferenceException($"Vaga inválida!");
            List<Tecnologia> tecnologias = new List<Tecnologia>();
            if (tecnologiasIds != null)
            {
                tecnologias = _context.Tecnologias
                                              .Where(tec => tecnologiasIds.Contains(tec.id))
                                              .ToList();
            }
            var state = vaga.HasId ? EntityState.Modified : EntityState.Added;

            if (state == EntityState.Added)
            {
                foreach (Tecnologia tecnologia in tecnologias)
                {
                    _context.Vagas_Tecnologias.Add(new Vaga_Tecnologia()
                    {
                        vaga = vaga,
                        tecnologia = tecnologia
                    });
                }
            }
            else
            {
                ModificarTecnologiasVaga(vaga, tecnologias);
            }

            _context.SaveChanges();
        }

        private void ModificarTecnologiasVaga(Vaga vaga, List<Tecnologia> tecnologias)
        {
            var tecnologiasDaVagaNoBanco = _context.Vagas_Tecnologias
                                                                           .Where(vt => vt.vaga.id == vaga.id)
                                                                           .Select(vt => vt.tecnologia)
                                                                           .ToList();

            var tecnologiasPraExcluir = tecnologiasDaVagaNoBanco
                                                    .Where(t => !tecnologias.Contains(t))
                                                    .ToList();
            var tecnologiasPraInserir = tecnologias
                                                .Where(t => !tecnologiasDaVagaNoBanco.Contains(t))
                                                .ToList();

            tecnologiasPraExcluir.ForEach(tec =>
            {
                var tecnologiaVaga = _context.Vagas_Tecnologias
                                                                    .Where(vt => vt.tecnologia.id == tec.id && vt.vaga.id == vaga.id)
                                                                    .FirstOrDefault();

                _context.Vagas_Tecnologias.Remove(tecnologiaVaga);
            });

            tecnologiasPraInserir.ForEach(tec =>
            {
                _context.Vagas_Tecnologias.Add(new Vaga_Tecnologia()
                {
                    vaga = vaga,
                    tecnologia = tec
                });
            });
        }


    }
}