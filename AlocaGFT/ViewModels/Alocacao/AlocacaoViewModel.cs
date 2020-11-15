using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AlocaGFT.Models;

namespace AlocaGFT.ViewModels.Alocacao
{
    public class AlocacaoViewModel
    {
        public List<AlocaGFT.Models.Alocacao> Alocacoes { get; set; }
        public List<VagaViewModel> Vagas { get; set; }
        [Required(ErrorMessage = "É Necessário selecionar uma vaga.")]
        public long? VagaId { get; set; }

    }
}