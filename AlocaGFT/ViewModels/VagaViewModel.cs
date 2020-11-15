using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AlocaGFT.Models;

namespace AlocaGFT.ViewModels
{
    public class VagaViewModel
    {
        public long? Id { get; set; }
        public bool HasId => this.Id > 0;
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Data de Abertura")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true, NullDisplayText = "Data inválida")]
        public DateTime? Abertura { get; set; }
        [Display(Name = "Código da vaga")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string CodigoVaga { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Projeto { get; set; }
        [Display(Name = "Quantidade de vagas restantes")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Range(0,Int32.MaxValue, ErrorMessage = "A quantidade de vagas, precisa ser maior, ou igual a {0}")]
        public int QtdVaga { get; set; }
        public bool HomeOffice { get; set; }

        [Display(Name = "Tecnologias")]
        public List<long> TecnologiaIds { get; set; }
        public List<Tecnologia> TecnologiasDaVaga { get; set; }

        public List<Funcionario> FuncionariosAlocados { get; set; }
    }
}