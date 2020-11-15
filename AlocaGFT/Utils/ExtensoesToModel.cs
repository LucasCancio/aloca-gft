using System;
using AlocaGFT.Models;
using AlocaGFT.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace AlocaGFT.Utils
{
    public static class ExtensoesToModel
    {
        public static Cargo ToModel(this CargoViewModel cargoVM)
        {
            var cargo = new Cargo()
            {
                id = (cargoVM.Id.HasValue ? cargoVM.Id.Value : 0),
                level = cargoVM.Level,
                nome = cargoVM.Nome,
                status = true
            };

            if (cargoVM.HasId) cargo.data_alteracao = DateTime.Now;
            return cargo;
        }


        public static Vaga ToModel(this VagaViewModel vagaVM)
        {
            var vaga = new Vaga()
            {
                id = (vagaVM.Id.HasValue ? vagaVM.Id.Value : 0),
                abertura = vagaVM.Abertura.Value,
                codigoVaga = vagaVM.CodigoVaga,
                descricao = vagaVM.Descricao,
                projeto = vagaVM.Projeto,
                qtdVaga = vagaVM.QtdVaga,
                homeOffice= vagaVM.HomeOffice,
                status = true
            };

            if (vagaVM.HasId) vaga.data_alteracao = DateTime.Now;
            return vaga;
        }


        public static Gft ToModel(this GftViewModel gftVM)
        {
            var gft = new Gft()
            {
                id = (gftVM.Id.HasValue ? gftVM.Id.Value : 0),
                nome = gftVM.Nome,
                endereco = gftVM.Endereco,
                telefone = gftVM.Telefone,
                status = true
            };

            if (gftVM.HasId) gft.data_alteracao = DateTime.Now;
            return gft;
        }

        public static Tecnologia ToModel(this TecnologiaViewModel tecnologiaVM)
        {
            var tecnologia = new Tecnologia()
            {
                id = (tecnologiaVM.Id.HasValue ? tecnologiaVM.Id.Value : 0),
                imageName = (tecnologiaVM.Image == null ? tecnologiaVM.ImageName : tecnologiaVM.Image.FileName),
                nome = tecnologiaVM.Nome,
                imageSource = tecnologiaVM.ImageSource,
                status = true
            };

            if (tecnologiaVM.HasId) tecnologia.data_alteracao = DateTime.Now;
            return tecnologia;
        }

        public static Funcionario ToModel(this FuncionarioViewModel funcionarioVM)
        {
            var funcionario = new Funcionario()
            {
                id = (funcionarioVM.Id.HasValue ? funcionarioVM.Id.Value : 0),
                nome = funcionarioVM.Nome,
                matricula = funcionarioVM.Matricula,
                inicio_wa = funcionarioVM.Inicio_wa.Value,
                termino_wa = funcionarioVM.Termino_wa.Value,
                status = true
            };

            return funcionario;
        }
    }
}