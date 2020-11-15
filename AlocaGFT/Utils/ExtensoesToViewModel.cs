using System.Collections.Generic;
using System.Linq;
using AlocaGFT.Interfaces.Repositories;
using AlocaGFT.Models;
using AlocaGFT.ViewModels;

namespace AlocaGFT.Utils
{
    public static class ExtensoesToViewModel
    {
        public static CargoViewModel ToViewModel(this Cargo cargo)
        {
            return new CargoViewModel()
            {
                Id = cargo.id,
                Level = cargo.level,
                Nome = cargo.nome
            };
        }

        public static VagaViewModel ToViewModel(this Vaga vaga, List<Tecnologia> tecnologiasDaVaga)
        {
            return new VagaViewModel()
            {
                Id = vaga.id,
                Abertura = vaga.abertura,
                CodigoVaga = vaga.codigoVaga,
                Descricao = vaga.descricao,
                Projeto = vaga.projeto,
                QtdVaga = vaga.qtdVaga,
                HomeOffice = vaga.homeOffice,
                TecnologiaIds = tecnologiasDaVaga.Select(tec => tec.id).ToList(),
                TecnologiasDaVaga = tecnologiasDaVaga
            };
        }

        public static GftViewModel ToViewModel(this Gft gft)
        {
            return new GftViewModel()
            {
                Endereco = gft.endereco,
                Id = gft.id,
                Nome = gft.nome,
                Telefone = gft.telefone
            };
        }

        public static TecnologiaViewModel ToViewModel(this Tecnologia tecnologia)
        {
            return new TecnologiaViewModel()
            {
                Id = tecnologia.id,
                Nome = tecnologia.nome,
                ImageName = tecnologia.imageName,
                ImageSource = tecnologia.imageSource
            };
        }

        public static FuncionarioViewModel ToViewModel(this Funcionario funcionario, List<Tecnologia> tecnologiasDoFunc)
        {
            return new FuncionarioViewModel()
            {
                Nome = funcionario.nome,
                Matricula = funcionario.matricula,
                Cargo = funcionario.cargo,
                CargoId = funcionario.cargo?.id,

                Gft = funcionario.gft,
                GftId = funcionario.gft?.id,

                VagaCod = funcionario.vaga?.codigoVaga,
                Id = funcionario.id,
                Inicio_wa = funcionario.inicio_wa,
                Termino_wa = funcionario.termino_wa,
                TecnologiaIds = tecnologiasDoFunc.Select(tec => tec.id).ToList(),
                TecnologiasDoFunc = tecnologiasDoFunc
            };
        }

        public static List<FuncionarioViewModel> ToViewModel(this List<Funcionario> funcionarios,
         ITecnologiaRepository tecnologiaRepository)
        {
            List<FuncionarioViewModel> funcionariosVM = new List<FuncionarioViewModel>();

            foreach (Funcionario funcionario in funcionarios)
            {
                var tecnologiasDoFunc = tecnologiaRepository.GetTecnologiasPorFuncionario(funcionario);

                funcionariosVM.Add(funcionario.ToViewModel(tecnologiasDoFunc));
            }
            return funcionariosVM;
        }

        public static List<VagaViewModel> ToViewModel(this List<Vaga> vagas,
         ITecnologiaRepository tecnologiaRepository)
        {
            List<VagaViewModel> vagasVM = new List<VagaViewModel>();

            foreach (Vaga vaga in vagas)
            {
                var tecnologiasDaVaga = tecnologiaRepository.GetTecnologiasPorVaga(vaga);

                vagasVM.Add(vaga.ToViewModel(tecnologiasDaVaga));
            }
            return vagasVM;
        }

    }
}