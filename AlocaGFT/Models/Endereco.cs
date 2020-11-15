using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AlocaGFT.Interfaces.Generics;

namespace AlocaGFT.Models
{
    public class Endereco : IDefaultCrudEntity
    {
        public long id { get; set; }
        public bool HasId => this.id > 0;
        [Display(Name = "Número")]
        public int numero { get; set; }
        [Display(Name = "Complemento")]
        public string complemento { get; set; }
        public float longitude { get; set; }
        public float latitude { get; set; }


        [Display(Name = "Cep")]
        [Required(ErrorMessage="O campo {0} é obrigatório!")]
        public string cep { get; set; }
        [Display(Name = "Cidade")]
        [Required(ErrorMessage="O campo {0} é obrigatório!")]
        public string cidade { get; set; }
        [Display(Name = "UF")]
        [Required(ErrorMessage="O campo {0} é obrigatório!")]
        public string uf { get; set; }
        [Display(Name = "Bairro")]
        [Required(ErrorMessage="O campo {0} é obrigatório!")]
        public string bairro { get; set; }
        [Display(Name = "Logradouro")]
        [Required(ErrorMessage="O campo {0} é obrigatório!")]
        public string logradouro { get; set; }


        public bool? status { get; set; } = true;
        public DateTime data_criacao { get; set; } = DateTime.Now;
        public DateTime? data_alteracao { get; set; }

    }
}