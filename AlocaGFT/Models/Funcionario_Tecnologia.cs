using System.ComponentModel.DataAnnotations.Schema;

namespace AlocaGFT.Models
{
    public class Funcionario_Tecnologia
    {
        public long id { get; set; }
        public Funcionario funcionario { get; set; }
        [ForeignKey("funcionario")]
        public long funcionarioid {get;set;}
        public Tecnologia tecnologia { get; set; }

        [ForeignKey("tecnologia")]
        public long tecnologiaid {get;set;}
    }
}