using System.ComponentModel.DataAnnotations;
using AlocaGFT.Models;

namespace AlocaGFT.ViewModels
{
    public class GftViewModel
    {
        public long? Id { get; set; }
        public bool HasId => this.Id > 0;
        [Required(ErrorMessage="O campo {0} é obrigatório!")]
        public string Nome { get; set; }
        [Required(ErrorMessage="O campo {0} é obrigatório!")]
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }
    }
}