using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AlocaGFT.Models;

namespace AlocaGFT.ViewModels.Alocacao
{
    public class VagaAlocacaoViewModel
    {
        [Required(ErrorMessage = "A vaga é obrigatória!")]
        public VagaViewModel Vaga { get; set; }
        public List<FuncionarioViewModel> FuncionariosEmWA { get; set; }
        public List<FuncionarioViewModel> FuncionariosAlocados { get; set; } = new List<FuncionarioViewModel>();
    }
}