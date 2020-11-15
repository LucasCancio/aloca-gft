using System.ComponentModel.DataAnnotations;
using AlocaGFT.Utils.Enums;

namespace AlocaGFT.ViewModels
{
    public class CargoViewModel
    {
        public long? Id { get; set; }
        public bool HasId => this.Id.HasValue && this.Id > 0;
        
        [Required(ErrorMessage="O campo {0} é obrigatório!")]
        public string Nome { get; set; }
        [Required(ErrorMessage="O campo {0} é obrigatório!")]
        public CargoLevels Level { get; set; }
    }
}