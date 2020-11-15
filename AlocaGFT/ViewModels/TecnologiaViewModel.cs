using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace AlocaGFT.ViewModels
{
    public class TecnologiaViewModel
    {
        public long? Id { get; set; }
        public bool HasId => this.Id > 0;
        [Required(ErrorMessage="O campo {0} é obrigatório!")]
        public string Nome { get; set; }

        
        [Display(Name = "Imagem")]
        public IFormFile Image { get; set; }
        public string ImageName { get; set; }
        [Display(Name = "Imagem do Produto")]
        public string ImageSource {get;set;}
    }
}