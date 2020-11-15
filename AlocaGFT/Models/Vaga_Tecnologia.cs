using System.ComponentModel.DataAnnotations.Schema;

namespace AlocaGFT.Models
{
    public class Vaga_Tecnologia
    {
        public long id { get; set; }
        public Vaga vaga { get; set; }
        [ForeignKey("vaga")]
        public long vagaid {get;set;}
        public Tecnologia tecnologia { get; set; }
        [ForeignKey("tecnologia")]
        public long tecnologiaid {get;set;}
    }
}