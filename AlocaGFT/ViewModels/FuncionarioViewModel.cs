using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AlocaGFT.Models;

namespace AlocaGFT.ViewModels
{
    public class FuncionarioViewModel
    {
        public long? Id { get; set; }
        public bool HasId => this.Id > 0;

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Data de inicio WA")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true, NullDisplayText = "Data inválida")]
        public DateTime? Inicio_wa { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Data de término WA")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true, NullDisplayText = "Data inválida")]
        public DateTime? Termino_wa { get; set; } = DateTime.Today.AddDays(15);

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Cargo")]
        public long? CargoId { get; set; }
        public Cargo Cargo { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Gft")]
        public long? GftId { get; set; }
        public Gft Gft { get; set; }


        [Display(Name = "Vaga")]
        public string VagaCod { get; set; }

        [Display(Name = "Tecnologias")]
        public List<long> TecnologiaIds { get; set; }

        public List<Tecnologia> TecnologiasDoFunc { get; set; }
    }
}